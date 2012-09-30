using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using localhost;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {}

	protected void cmdGetData_Click(object sender, EventArgs e)
	{
		// Create the proxy.
		EmployeesService proxy = new EmployeesService();

		Uri newUrl = new Uri(proxy.Url);
		proxy.Url = newUrl.Scheme + "://" + newUrl.Host + ":8080" + newUrl.AbsolutePath;

		// Call the web service and get the results.
		GridView1.DataSource = proxy.GetEmployees();
		GridView1.DataBind();
    }
}