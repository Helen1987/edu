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

public partial class DynamicPanelTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void Panel1_Refreshing(object sender, EventArgs e)
	{
		Label1.Text = "This was refreshed without a postback at " +
			DateTime.Now.ToString();
	}
}
