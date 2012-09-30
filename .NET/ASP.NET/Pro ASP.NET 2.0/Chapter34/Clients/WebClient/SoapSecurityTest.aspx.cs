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
using localhost;

public partial class SoapSecurityTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void cmdCall_Click(object sender, EventArgs e)
	{
		SoapSecurityService proxy = new SoapSecurityService();

		try
		{
			proxy.Login(txtUserName.Text, txtPassword.Text);
			GridView1.DataSource = proxy.GetEmployees();
			GridView1.DataBind();
		}
		catch (Exception err)
		{
			lblInfo.Text = err.Message;
		}

	}
	protected void cmdCreate_Click(object sender, EventArgs e)
	{
		SoapSecurityService proxy = new SoapSecurityService();
		try
		{
			proxy.CreateTestUser(txtUserName.Text, txtPassword.Text);
			lblInfo.Text = "Successfully added this user as an administrator.";
		}
		catch (Exception err)
		{
			lblInfo.Text = err.Message;
		}
	}
}
