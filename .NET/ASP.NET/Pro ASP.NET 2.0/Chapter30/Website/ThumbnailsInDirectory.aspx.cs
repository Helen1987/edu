using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;


public partial class ThumbnailsInDirectory : System.Web.UI.Page
{

	protected void cmdShow_Click(object sender, System.EventArgs e)
	{
		// Get a string array with all the image files.
		DirectoryInfo dir = new DirectoryInfo(txtDir.Text);
		gridThumbs.DataSource = dir.GetFiles("*.bmp");

		// Bind the string array.
		gridThumbs.DataBind();
	}

	protected string GetImageUrl(object path)
	{
		return "ThumbnailViewer.aspx?x=50&y=50&FilePath=" +
			Server.UrlEncode((string)path);
	}

	protected void Page_Load(object sender, System.EventArgs e)
	{

	}

}