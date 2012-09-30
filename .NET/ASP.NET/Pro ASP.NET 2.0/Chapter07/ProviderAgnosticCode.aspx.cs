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
using System.Data.Common;
using System.Text;
using System.Web.Configuration;

public partial class ProviderAgnosticCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Get the factory.
		string factory = WebConfigurationManager.AppSettings["factory"];
		DbProviderFactory provider = DbProviderFactories.GetFactory(factory);

		// Use this factory to create a connection.
		DbConnection con = provider.CreateConnection();
		con.ConnectionString =
			WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		
		// Create the command.
		DbCommand cmd = provider.CreateCommand();
		cmd.CommandText = WebConfigurationManager.AppSettings["employeeQuery"];
		cmd.Connection = con;

		// Open the Connection and get the DataReader.
		con.Open();
		DbDataReader reader = cmd.ExecuteReader();

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
