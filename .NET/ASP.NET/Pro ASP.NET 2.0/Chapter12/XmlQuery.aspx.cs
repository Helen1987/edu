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
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Xml;
using System.Text;

public partial class XmlQuery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

		// Define the command.
		string customerQuery =
		"SELECT FirstName, LastName FROM Employees FOR XML AUTO, ELEMENTS";
		SqlConnection con = new SqlConnection(connectionString);
		SqlCommand com = new SqlCommand(customerQuery, con);

		// Execute the command.
		StringBuilder str = new StringBuilder();
		try
		{
			con.Open();
			XmlReader reader = com.ExecuteXmlReader();

			while (reader.Read())
			{
				// Process each employee.
				if ((reader.Name == "Employees") && (reader.NodeType == XmlNodeType.Element))
				{
					reader.ReadStartElement("Employees");
					str.Append(reader.ReadElementString("FirstName"));
					str.Append(" ");
					str.Append(reader.ReadElementString("LastName"));
					str.Append("<br>");
					reader.ReadEndElement();
				}
			}
			reader.Close();
		}
		finally
		{
			con.Close();
		}
		XmlText.Text = str.ToString();
    }
}
