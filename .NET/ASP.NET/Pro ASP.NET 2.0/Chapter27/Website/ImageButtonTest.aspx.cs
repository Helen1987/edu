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

public partial class ImageButtonTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}
	
	protected void CustomImageButton1_ImageClicked(object sender, EventArgs e)
	{
		int count = 0;
		if (ViewState["count"] != null) count = (int)ViewState["count"];
		count++;
		Response.Write("Clicked " + count.ToString());
		ViewState["count"] = count;
	}
}
