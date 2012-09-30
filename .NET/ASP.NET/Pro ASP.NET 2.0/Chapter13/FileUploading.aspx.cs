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

public partial class FileUploading : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void cmdUpload_Click(object sender, EventArgs e)
	{
		// Check if a file was submitted.
		if (Uploader.PostedFile.ContentLength != 0)
		{
			try
			{
				if (Uploader.PostedFile.ContentLength > 1064)
				{
					// This exceeds the size limit you want to allow,.
					// You should check the size to prevent a denial of
					// service attack that attempts to fill up your
					// web server's hard drive.
					// You might also want to check the amount of 
					// remaining free space.
					lblStatus.Text = "Too large. This file is not allowed";
				}
				else
				{
					// Retrieve the physical directory path for the Upload
					// subdirectory.
					string destDir = Server.MapPath("./Upload");

					// Extract the file name part from the full path of the
					// original file.
					string fileName = System.IO.Path.GetFileName(
					  Uploader.PostedFile.FileName);

					// Combine the destination directory with the file name.
					string destPath = System.IO.Path.Combine(destDir, fileName);

					// Save the file on the server.
					Uploader.PostedFile.SaveAs(destPath);
					lblStatus.Text = "Thanks for submitting your file";

					// Display the whole file content.
					//StreamReader r = new StreamReader(Uploader.PostedFile.InputStream);
					//lblStatus.Text = r.ReadToEnd();
					//r.Close();
				}
			}
			catch (Exception err)
			{
				lblStatus.Text = err.Message;
			}
		}

	}
}
