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
using System.Diagnostics;

public partial class FileBrowser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			ShowDirectoryContents(Server.MapPath("."));
		}
	}

	private void ShowDirectoryContents(string path)
	{
		// Define the current directory.
		DirectoryInfo dir = new DirectoryInfo(path);

		// Get the DirectoryInfo and FileInfo objects.
		FileInfo[] files = dir.GetFiles();
		DirectoryInfo[] dirs = dir.GetDirectories();

		// Show the directory listing.
		lblCurrentDir.Text = "Currently showing " + path;
		gridFileList.DataSource = files;
		gridDirList.DataSource = dirs;
		Page.DataBind();

		// Clear any selection.
		gridFileList.SelectedIndex = -1;

		// Keep track of the current path.
		ViewState["CurrentPath"] = path;
	}

	protected void gridFileList_SelectedIndexChanged(object sender, EventArgs e)
	{
		// Get the selected file.
		string file = (string)gridFileList.DataKeys[gridFileList.SelectedIndex].Value;

		// The FormView shows a collection (or list) of items.
		// To accommodate this model, you must add the file object
		// to a collection of some sort.
		ArrayList files = new ArrayList();
		files.Add(new FileInfo(file));


		// Now show the selected file.
		formFileDetails.DataSource = files;
		formFileDetails.DataBind();
	}

	protected string GetVersionInfoString(object path)
	{
		FileVersionInfo info = FileVersionInfo.GetVersionInfo((string)path);
		return info.FileName + " " + info.FileVersion + "<br>" +
			info.ProductName + " " + info.ProductVersion;
	}
	protected void cmdUp_Click(object sender, EventArgs e)
	{
		string path = (string)ViewState["CurrentPath"];
		path = Path.Combine(path, "..");
		path = Path.GetFullPath(path);
		ShowDirectoryContents(path);
	}

	protected void gridDirList_SelectedIndexChanged(object sender, EventArgs e)
	{
		// Get the selected directory.
		string dir = (string)gridDirList.DataKeys[gridDirList.SelectedIndex].Value;

		// Now refresh the directory list to
		// show the selected directory.
		ShowDirectoryContents(dir);
	}
}
