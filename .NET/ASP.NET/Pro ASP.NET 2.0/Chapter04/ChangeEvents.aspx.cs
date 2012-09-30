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

public partial class ChangeEvents : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			List1.Items.Add("Option 3");
			List1.Items.Add("Option 4");
			List1.Items.Add("Option 5");
		}
	}

	protected void Ctrl_ServerChange(object sender, System.EventArgs e)
	{
		Response.Write("<li>ServerChange detected for " +
		  ((Control)sender).ID + "</li>");
	}

	protected void List1_ServerChange(object sender, EventArgs e)
	{
		Response.Write("<li>ServerChange detected for List1. " +
	 "The selected items are:</li><br/>");
		foreach (ListItem li in List1.Items)
		{
			if (li.Selected)
				Response.Write("&nbsp;&nbsp;- " + li.Value + "<br/>");
		}

	}
	protected void Submit1_ServerClick(object sender, EventArgs e)
	{
		Response.Write("<li>ServerClick detected for Submit1.</li>");
	}
}
