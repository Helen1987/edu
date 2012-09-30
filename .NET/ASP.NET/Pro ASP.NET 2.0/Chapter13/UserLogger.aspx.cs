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

public partial class UserLogger : System.Web.UI.Page
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
				StreamReader r = new StreamReader(fs);

				// Read line by line (allows you to add
				// line breaks to the web page).
				string line;
				do
				{
					line = r.ReadLine();
					if (line != null)
					{
						lblInfo.Text += line + "<br>";
					}
				} while (line != null);

				r.Close();
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
			StreamWriter w = new StreamWriter(fs);
			w.WriteLine(DateTime.Now);
			w.WriteLine(message);
			w.Close();
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
