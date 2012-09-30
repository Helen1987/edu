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

public partial class DataSetXml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// create the connection, DataAdapter and DataSet
		string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
		string sql = "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees";
		SqlConnection conn = new SqlConnection(connectionString);
		SqlDataAdapter da = new SqlDataAdapter(sql, conn);
		DataSet ds = new DataSet();

		// Fill the DataSet and fill the first grid.
		da.Fill(ds, "Employees");
		Datagrid1.DataSource = ds.Tables["Employees"];
		Datagrid1.DataBind();

		// Generate the XML file.
		string xmlFile = Server.MapPath("Employees.xml");
		ds.WriteXml(xmlFile, XmlWriteMode.WriteSchema);

		// Load the XML file.
		DataSet dsXml = new DataSet();
		dsXml.ReadXml(xmlFile);
		// Fill the second grid.
		Datagrid2.DataSource = dsXml.Tables["Employees"];
		Datagrid2.DataBind();

    }
}
