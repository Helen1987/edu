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

public partial class MultipleViews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			DropDownList1.DataSource = MultiView1.Views;
			DropDownList1.DataTextField = "ID";
			DropDownList1.DataBind();
		}

    }
	
	protected void cmdShow_Click(object sender, EventArgs e)
	{
		MultiView1.ActiveViewIndex = DropDownList1.SelectedIndex;
	}
	protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
	{
		DropDownList1.SelectedIndex = MultiView1.ActiveViewIndex;
	}
}
