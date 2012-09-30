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
using System.Text;
using System.Web.Configuration;

public partial class DataReader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Create the Command and the Connection.
		string connectionString =
  WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

		SqlConnection con = new SqlConnection(connectionString);
		string sql = "SELECT * FROM Employees";
		SqlCommand cmd = new SqlCommand(sql, con);

		// Open the Connection and get the DataReader.
		con.Open();
		SqlDataReader reader = cmd.ExecuteReader();

		// Cycle through the records, and build the HTML string.
		StringBuilder htmlStr = new StringBuilder("");
		while (reader.Read())
		{
			htmlStr.Append("<li>");
			htmlStr.Append(reader["TitleOfCourtesy"]);
			htmlStr.Append(" <b>");
			htmlStr.Append(reader.GetString(1));
			htmlStr.Append("</b>, ");
			htmlStr.Append(reader.GetString(2));
			htmlStr.Append(" - employee from ");
			htmlStr.Append(reader.GetDateTime(6).ToString("d"));
			htmlStr.Append("</li>");
		}

		// Close the DataReader and the Connection.
		reader.Close();
		con.Close();

		// Show the generated HTML code on the page.
		HtmlContent.Text = htmlStr.ToString();
    }
}
