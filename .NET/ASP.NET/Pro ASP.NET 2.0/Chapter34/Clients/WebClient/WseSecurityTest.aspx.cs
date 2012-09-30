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
using Microsoft.Web.Services3.Security.Tokens;

public partial class WseSecurityTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void cmdCallWithout_Click(object sender, EventArgs e)
	{
		EmployeesService proxy = new EmployeesService();
		GridView1.DataSource = proxy.GetEmployeesWseSecured();
		GridView1.DataBind();
	}
	protected void cmdCallWith_Click(object sender, EventArgs e)
	{
		EmployeesServiceWse proxy = new EmployeesServiceWse();

		//Uri newUrl = new Uri(proxy.Url);
		//proxy.Url = newUrl.Scheme + "://" + newUrl.Host + ":8080" + newUrl.AbsolutePath;

		// Add the WS-Security token.
		proxy.RequestSoapContext.Security.Tokens.Add(
		  new UsernameToken("dan", "secret", PasswordOption.SendPlainText ));

		GridView1.DataSource = proxy.GetEmployeesWseSecured();
		GridView1.DataBind();
	}
}
