using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

public partial class UserLoggerSerialization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			Log("Page loaded for the first time.");
		}
		else
		{
			Log("Page posted back.");
		}
    }
	protected void cmdRead_Click(object sender, EventArgs e)
	{
		if (ViewState["LogFile"] != null)
		{
			string fileName = (string)ViewState["LogFile"];
			using (FileStream fs = new FileStream(fileName, FileMode.Open))
			{
				// Create a formatter.
				BinaryFormatter formatter = new BinaryFormatter();

				// Get all the serialized objects.
				while (fs.Position < fs.Length)
				{
					// Deserialize the object from the file.
					LogEntry entry = (LogEntry)formatter.Deserialize(fs);

					// Display its information.
					lblInfo.Text += entry.Date.ToString() + "<br>";
					lblInfo.Text += entry.Message + "<br>";
				}
			}
		}
	}
	protected void cmdDelete_Click(object sender, EventArgs e)
	{
		if (ViewState["LogFile"] != null)
		{
			File.Delete((string)ViewState["LogFile"]);
		}	
	}

	private void Log(string message)
	{
		// Check for the file.	
		FileMode mode;
		if (ViewState["LogFile"] == null)
		{
			// First, create a unique user-specific file name.
			ViewState["LogFile"] = GetFileName();

			// The log file must be created.
			mode = FileMode.Create;
		}
		else
		{
			// Add to the existing file.
			mode = FileMode.Append;
		}

		// Write the message.
		// A using block ensures the file is automatically closed,
		// even in the case of error.
		string fileName = (string)ViewState["LogFile"];
		using (FileStream fs = new FileStream(fileName, mode))
		{
			// Create a LogEntry object.
			LogEntry entry = new LogEntry(message);

			// Create a formatter.
			BinaryFormatter formatter = new BinaryFormatter();
			//SoapFormatter formatter = new SoapFormatter();

			// Serialize the object to a file.
			formatter.Serialize(fs, entry);

			// Serialize to a memory stream so you can display it.
			MemoryStream ms = new MemoryStream();
			formatter.Serialize(ms, entry);

			// Read it back and write it to the Debug window.
			StreamReader r = new StreamReader(ms, System.Text.Encoding.ASCII);
			ms.Position = 0;
			string x = r.ReadToEnd();
			r.Close();
			ms.Close();
		}
	}

	private string GetFileName()
	{
		// Create a unique filename.
		string fileName = "user." +
			Guid.NewGuid().ToString();

		// Put the file in the current web application path.
		return Path.Combine(Request.PhysicalApplicationPath, fileName);
	}
}
[Serializable()]
public class LogEntry
{
	private string message;
	private DateTime date;

	public string Message
	{
		get { return message; }
		set { message = value; }
	}
	public DateTime Date
	{
		get { return date; }
		set { date = value; }
	}

	public LogEntry(string message)
	{
		this.message = message;
		this.date = DateTime.Now;
	}
}