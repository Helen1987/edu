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

public partial class PageFlow : System.Web.UI.Page
{
	private void Page_Load(object sender, System.EventArgs e)
	{
		lblInfo.Text += "Page.Load event handled.<br/>";
		if (Page.IsPostBack)
		{
			lblInfo.Text +=
			  "<b>This is the second time you've seen this page.</b><br/>";
		}
	}

	private void Page_Init(object sender, System.EventArgs e)
	{
		lblInfo.Text += "Page.Init event handled.<br/>";
	}

	protected void Button1_Click(object sender, System.EventArgs e)
	{
		lblInfo.Text += "Button1.Click event handled.<br/>";
	}

	private void Page_PreRender(object sender, System.EventArgs e)
	{
		lblInfo.Text += "Page.PreRender event handled.<br/>";
	}

	private void Page_Unload(object sender, System.EventArgs e)
	{
		// This text never appears because the HTML is already
		// rendered for the page at this point.
		lblInfo.Text += "Page.Unload event handled.<br/>";
	}

}
