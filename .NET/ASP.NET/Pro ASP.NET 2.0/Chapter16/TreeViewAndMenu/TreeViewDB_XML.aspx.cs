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
using System.Xml;

public partial class TreeViewDB_XML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
		string connectionString =
  WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		SqlConnection con = new SqlConnection(connectionString);

		string sql = "SELECT C.CategoryName, C.CategoryID, P.ProductName, P.ProductID FROM Products P INNER JOIN Categories C ON P.CategoryID = C.CategoryID FOR XML AUTO, ELEMENTS";

		SqlCommand cmd = new SqlCommand(sql, con);

		string xml = "";
		try
		{
			con.Open();

			XmlReader r = cmd.ExecuteXmlReader();
			r.Read();
			xml = "<root>" + r.ReadOuterXml() + "</root>";
		}
		finally
		{
			con.Close();
		}
		sourceDbXml.Data = xml;
    }
}
