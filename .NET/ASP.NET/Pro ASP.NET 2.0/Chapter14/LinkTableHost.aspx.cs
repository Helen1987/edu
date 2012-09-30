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

public partial class LinkTableHost : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Set the title.
		LinkTable1.Title = "A List of Links";

		// Set the hyperlinked item list.
		LinkTableItem[] items = new LinkTableItem[3];
		items[0] = new LinkTableItem("Test Item 1", "http://www.apress.com");
		items[1] = new LinkTableItem("Test Item 2", "http://www.apress.com");
		items[2] = new LinkTableItem("Test Item 3", "http://www.apress.com");
		LinkTable1.Items = items;

	}


	protected void LinkClicked(object sender, LinkTableEventArgs e)
	{
		lblInfo.Text = "You clicked '" + e.SelectedItem.Text +

		  "' but this page chose not to direct you to '" +
		e.SelectedItem.Url + "'.";
		e.Cancel = true;
	}

}
