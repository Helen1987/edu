using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class TrimViewState : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		for (int i = 0; i < 1000; i++)
		{
			lstBig.Items.Add(i.ToString());
		}

		if (Page.IsPostBack)
		{
			lstBig.SelectedItem.Text = Request.Form["lstBig"];
		}
    }
	protected void cmdSubmit_Click(object sender, EventArgs e)
	{
		lblInfo.Text += lstBig.SelectedItem.Text + "<br />";
		//lblInfo.Text = Request.Form["lstBig"];
	}

}