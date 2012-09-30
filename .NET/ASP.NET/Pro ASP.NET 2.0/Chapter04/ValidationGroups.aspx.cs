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

public partial class ValidationGroups : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }
	protected void cmdValidateAll_Click(object sender, EventArgs e)
	{
		Label1.Text = "Valid: " + Page.IsValid.ToString();
		Page.Validate("Group1");
		Label1.Text += "<br />Group1 Valid: " + Page.IsValid.ToString();
		Page.Validate("Group2");
		Label1.Text += "<br />Group2 Valid: " + Page.IsValid.ToString();
	}
}
