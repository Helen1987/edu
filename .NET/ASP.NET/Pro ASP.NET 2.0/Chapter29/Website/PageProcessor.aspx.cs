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

public partial class PageProcessor : System.Web.UI.Page
{
	protected string PageToLoad;

	protected void Page_Load(object sender, System.EventArgs e)
	{
		PageToLoad = Request.QueryString["Page"];
	}

}
