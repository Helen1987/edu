using System;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.IO;

[AttributeUsage(AttributeTargets.Method)]
public class SoapLogAttribute : System.Web.Services.Protocols.SoapExtensionAttribute
{
	private int m_Priority;
	private string m_Name = "SoapLog" ;
	private int m_Level = 1;
  
	public override int Priority
	{
		get { return m_Priority; }
		set { m_Priority = value; }
	}

	public string Name
	{
		get { return m_Name;}
		set { m_Name = value; }
	}
	public int Level
	{
		get { return m_Level;}
		set { m_Level = value; }
	}

	public override Type ExtensionType
	{
		get { return typeof(SoapLog); }
	}

}

public class SoapLog : System.Web.Services.Protocols.SoapExtension
{
	private Stream oldStream;
	private Stream newStream;
	private string name;
	private int level;

	public override object GetInitializer(
		System.Web.Services.Protocols.LogicalMethodInfo methodInfo, 
		System.Web.Services.Protocols.SoapExtensionAttribute attribute) 
	{
		return (SoapLogAttribute) attribute;
	}

	public override object GetInitializer(Type obj) 
	{
		return new SoapLogAttribute();
	}

	public override void Initialize(object initializer) 
	{
		name = ((SoapLogAttribute)initializer).Name;
		level = ((SoapLogAttribute)initializer).Level;
	}



	public override void ProcessMessage(
		System.Web.Services.Protocols.SoapMessage message) 
	{
		switch (message.Stage) 
		{
			case System.Web.Services.Protocols.SoapMessageStage.BeforeSerialize:
				if (level > 2 )
					WriteToLog(message.Stage.ToString(),
						EventLogEntryType.Information);
				break;
			case System.Web.Services.Protocols.SoapMessageStage.AfterSerialize:
				LogOutputMessage(message);
				break;
			case System.Web.Services.Protocols.SoapMessageStage.BeforeDeserialize:
				LogInputMessage(message);
				break;
			case System.Web.Services.Protocols.SoapMessageStage.AfterDeserialize:
				if (level > 2 )
					WriteToLog(message.Stage.ToString(),
						EventLogEntryType.Information);
				break;
		}
	}

	public override Stream ChainStream(Stream stream)
	{
		oldStream = stream;
		newStream = new MemoryStream();
		return newStream;
	}


	private void CopyStream(Stream fromstream, Stream tostream)
	{
		StreamReader reader = new StreamReader(fromstream);
		StreamWriter writer = new StreamWriter(tostream);
      
		writer.WriteLine(reader.ReadToEnd());
		writer.Flush();
	}

	private void LogInputMessage(SoapMessage message)
	{
		CopyStream(oldStream, newStream);
		message.Stream.Seek(0, SeekOrigin.Begin);
		LogMessage(message, newStream);
		message.Stream.Seek(0, SeekOrigin.Begin);
	}

	private void LogOutputMessage(SoapMessage message)
	{
		message.Stream.Seek(0, SeekOrigin.Begin);
		LogMessage(message, newStream);
		message.Stream.Seek(0, SeekOrigin.Begin);
		CopyStream(newStream, oldStream);
	}

	private void LogMessage(SoapMessage message, Stream stream)
	{
		String eventMessage;
		TextReader reader;

		reader = new StreamReader(stream);
		eventMessage = reader.ReadToEnd();

		if (level > 2)
			eventMessage = message.Stage.ToString() +"\n" + eventMessage;

		if (eventMessage.IndexOf("<soap:Fault>") > 0)
		{
			//The SOAP body contains a fault
			if (level > 0) 
				WriteToLog(eventMessage, EventLogEntryType.Error);
		}
		else
		{
			// The SOAP body contains a message
			if (level > 1)
				WriteToLog(eventMessage, EventLogEntryType.Information);	
		}
	}

	private void WriteToLog(String message, EventLogEntryType type)
	{
		EventLog log;

		if (!EventLog.SourceExists(name))
			EventLog.CreateEventSource(name, "Web Service Log");


		log = new EventLog();
		log.Source = name;

		log.WriteEntry(message, type);
	}

}
