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
using System.Data.SqlClient;

public partial class SqlDataSourceLimits : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			lstCities.DataSource = sourceEmployeeCities.Select(DataSourceSelectArguments.Empty);
			lstCities.DataBind();
			lstCities.Items.Insert(0, "(Choose a City)");
			lstCities.Items.Insert(1, "(All Cities)");
			lstCities.SelectedIndex = 0;
		}
    }
	protected override void OnPreRenderComplete(EventArgs e)
	{

	}

	protected void sourceEmployees_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
	{
		if ((string)e.Command.Parameters["@City"].Value == "(Choose a City)")
		{
			// Do nothing.
			e.Cancel = true;
		}
		else if ((string)e.Command.Parameters["@City"].Value == "(All Cities)")
		{
			// Manually change the command.
			e.Command.CommandText = "SELECT * FROM Employees";
		}
	}
}
