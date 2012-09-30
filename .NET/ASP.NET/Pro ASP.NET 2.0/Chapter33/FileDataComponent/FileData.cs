using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace FileDataComponent
{
	[XmlRoot(Namespace = "http://www.apress.com/ProASP.NET/FileData")]
	[XmlSchemaProvider("GetSchemaDocument")]
	public class FileData : IXmlSerializable
	{
		private const string ns = "http://www.apress.com/ProASP.NET/FileData";

		// The server-side path.
		private string serverFilePath;
		

		public FileData(string serverFilePath)
		{
			if (!File.Exists(serverFilePath))
			{
				throw new InvalidOperationException("Source file not found.");
			}
			this.serverFilePath = serverFilePath;
		}

		void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
		{
			// Open the file.
			FileStream fs = new FileStream(serverFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
			long length = fs.Length;

			// Write file name.
			writer.WriteElementString("fileName", ns, Path.GetFileName(serverFilePath));

			// Write file size (useful for determining progress.)
			writer.WriteElementString("size", ns, length.ToString());

			// Start the file content.
			writer.WriteStartElement("content", ns);

			// Read 4 KB chunks and write that (Base64 encoded).
			int bufferSize = 4096;
			byte[] fileBytes = new byte[bufferSize];
			int readBytes = bufferSize;

			while (readBytes > 0)
			{
				readBytes = fs.Read(fileBytes, 0, bufferSize);
				writer.WriteStartElement("chunk", ns);
				writer.WriteBase64(fileBytes, 0, readBytes);
				writer.WriteEndElement();
				writer.Flush();

			}

			fs.Close();

			// End the XML.
			writer.WriteEndElement();
			writer.Flush();

		}

		// The location to place the downloaded file.
		// Must be set before the download begins.
		public static string ClientFolder;

		public FileData()
		{ }



		System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
		{
			if (FileData.ClientFolder == null || FileData.ClientFolder == "")
			{
				throw new InvalidOperationException("No target folder specified.");
			}
			reader.ReadStartElement();

			// Get the original file name (not currently used).
			string fileName = reader.ReadElementString("fileName", ns);

			// Get the size (not currently used).
			double size = Convert.ToDouble(reader.ReadElementString("size", ns));

			// Create the file.
			FileStream fs = new FileStream(Path.Combine(ClientFolder, fileName), FileMode.Create, FileAccess.Write);

			// Read the XML and write the file one block at a time.
			byte[] fileBytes;
			reader.ReadStartElement("content", ns);
			double totalRead = 0;

			while (true)
			{
				if (reader.IsStartElement("chunk", ns))
				{
					string bytesBase64 = reader.ReadElementString();
					totalRead += bytesBase64.Length;
					fileBytes = Convert.FromBase64String(bytesBase64);
					fs.Write(fileBytes, 0, fileBytes.Length);
					fs.Flush();

					// You could report progress by raising an event here.
					Console.WriteLine("Received chunk.");
				}
				else
				{
					break;
				}
			}
			fs.Close();
			reader.ReadEndElement();
			reader.ReadEndElement();
		}


		public static XmlQualifiedName GetSchemaDocument(XmlSchemaSet xs)
		{
			// In the client, don't return the schema.
			if (HttpContext.Current == null) return null;

			// Get the path to the schema file.
			string schemaPath = HttpContext.Current.Server.MapPath("FileData.xsd");

			// Retrieve the schema from the file.
			XmlSerializer schemaSerializer = new XmlSerializer(typeof(XmlSchema));
			XmlSchema s = (XmlSchema)schemaSerializer.Deserialize(
			  new XmlTextReader(schemaPath), null);
			xs.XmlResolver = new XmlUrlResolver();
			xs.Add(s);

			return new XmlQualifiedName("FileData", ns);
		}

	}
}