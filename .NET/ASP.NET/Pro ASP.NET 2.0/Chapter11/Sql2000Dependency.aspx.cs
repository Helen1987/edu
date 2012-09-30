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
using System.Web.Configuration;
using System.Web.Caching;

public partial class Sql2000Dependency : System.Web.UI.Page
{
	protected void Page_PreRender(object sender, EventArgs e)
	{
		lblInfo.Text += "<br />";
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			lblInfo.Text += "Creating dependent item...<br />";
			Cache.Remove("CachedItem");
			// Create a dependency for the Employees table.
			SqlCacheDependency dependency = new SqlCacheDependency(
			  "Northwind", "Employees");


			DataTable dt = GetEmployeeTable();
			lblInfo.Text += "Adding dependent item<br>";
            Cache.Insert("CachedItem", dt, dependency);
		}
	}


	private string connectionString =
  WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
	private DataTable GetEmployeeTable()
	{
		SqlConnection con = new SqlConnection(connectionString);
		string sql = "SELECT * FROM Employees";
		SqlDataAdapter da = new SqlDataAdapter(sql, con);
		DataSet ds = new DataSet();
        da.Fill(ds, "Employees");
		return ds.Tables[0];
	}

	protected void cmdModfiy_Click(object sender, EventArgs e)
	{
		SqlConnection con = new SqlConnection(connectionString);
		// Even a change that really does do anything is still a change.
		string sql = "UPDATE Employees SET LastName='Davolio' WHERE LastName='Davolio'";
		SqlCommand cmd = new SqlCommand(sql, con);

		try
		{
			con.Open();
			cmd.ExecuteNonQuery();
		}
		finally
		{
			con.Close();
		}
		lblInfo.Text += "Update completed (remember to wait for poll time to pass).<br />";
	}
	protected void cmdGetItem_Click(object sender, EventArgs e)
	{
        if (Cache["CachedItem"] == null)
		{
			lblInfo.Text += "Cache item no longer exits.<br />";
		}
		else
		{
			lblInfo.Text += "Item is still present.<br />";
		}
	}
}
