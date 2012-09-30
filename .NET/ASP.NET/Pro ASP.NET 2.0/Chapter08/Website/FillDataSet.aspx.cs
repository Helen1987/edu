using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

public partial class FillDataSet : System.Web.UI.Page
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the Connection, DataAdapter, and DataSet.
		string connectionString = "Data Source=localhost;Initial Catalog=Northwind;" +
			"Integrated Security=SSPI";
		SqlConnection con = new SqlConnection(connectionString);
		string sql = "SELECT * FROM Employees";

		SqlDataAdapter da = new SqlDataAdapter(sql, con);
		DataSet ds = new DataSet();

		// Fill the DataSet.
		da.Fill(ds, "Employees");

		// Cycle through the records, and build the HTML string.
		StringBuilder htmlStr = new StringBuilder("");
		foreach (DataRow dr in ds.Tables["Employees"].Rows)
		{
			htmlStr.Append("<li>");
			htmlStr.Append(dr["TitleOfCourtesy"].ToString());
			htmlStr.Append(" <b>");
			htmlStr.Append(dr["LastName"].ToString());
			htmlStr.Append("</b>, ");
			htmlStr.Append(dr["FirstName"].ToString());
			htmlStr.Append("</li>");
		}

		// Show the generated HTML string.
		HtmlContent.Text = htmlStr.ToString();

		// Bind the DataSet to the Repeater.
		Repeater1.DataSource = ds;
		Repeater1.DataMember = "Employees";
		Repeater1.DataBind();

	}
}
