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

public partial class FocusAndDefault : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void cmdSubmit_Click(object sender, EventArgs e)
	{
		Label1.Text = "Clicked Submit.";
	}
	protected void cmdSetFocus1_Click(object sender, EventArgs e)
	{
		TextBox1.Focus();
	}
	protected void cmdSetFocus2_Click(object sender, EventArgs e)
	{
		TextBox2.Focus();
	}
}
