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
using System.Net;

public partial class ManualBinding : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void cmdGetData_Click(object sender, EventArgs e)
	{
		// Create the proxy.
		EmployeesService proxy = new EmployeesService();

		// This timeout will apply to all web service method calls.
		proxy.Timeout = 3000;  // 3,000 milliseconds is 3 seconds.

		DataSet ds = null;
		try
		{
			// Call the web service and get the results.
			ds = proxy.GetEmployees();
		}
		catch (System.Net.WebException err)
		{
			if (err.Status == WebExceptionStatus.Timeout)
			{
				lblResult.Text = "Web service timed out after 3 seconds.";
			}
			else
			{
				lblResult.Text = "Another type of problem occurred.";
			}
		}
		// Bind the results.
		if (ds != null)
		{
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();
		}


	}
}
