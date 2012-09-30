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

public partial class JavaScriptConfirm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

		string script = @"<script type='text/javascript' language='JavaScript'>
            function confirmSubmit() {
				var doc = document.forms[0];
				var msg = 'Are you sure you want to submit this data?';
				return confirm(msg);
				
			}
			</script>";

		Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Confirm", script);

		form1.Attributes.Add("onSubmit", "return confirmSubmit();");
		
    }
	protected void cmdSubmit_ServerClick(object sender, EventArgs e)
	{
		
	}
}
