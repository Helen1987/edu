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

public partial class GridViewDataBind : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			// Create the command and the connection.
			string connectionString = "Data Source=localhost;" +
			  "Initial Catalog=Northwind;Integrated Security=SSPI";
			string sql = "SELECT EmployeeID, FirstName, LastName, Title, City FROM Employees";
			SqlConnection con = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(sql, con);

			try
			{
				// Open the connection and get the DataReader.
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				// Bind the DataReader to the list.
				grid.DataSource = reader;
				grid.DataBind();
				reader.Close();
			}
			finally
			{
				// Close the connection.
				con.Close();
			}
		}
	}

}
