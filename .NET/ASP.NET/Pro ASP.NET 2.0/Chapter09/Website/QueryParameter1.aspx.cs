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

public partial class QueryParameter1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }

	protected void cmdGo_Click(object sender, EventArgs e)
	{
		Response.Redirect("QueryParameter2.aspx?city=" + lstCities.SelectedValue);
	}
}
