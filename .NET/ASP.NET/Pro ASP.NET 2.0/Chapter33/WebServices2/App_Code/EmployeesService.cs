using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using DatabaseComponent;
using System.Data.SqlClient;
using System.Xml;
using System.Web.Configuration;

/// <summary>
/// Summary description for EmployeesService
/// </summary>
[WebService(Namespace = "http://www.apress.com/ProASP.NET/Compat")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class EmployeesService : System.Web.Services.WebService 
{
	[WebMethod(Description = "Returns the full list of employees.")]
	public EmployeeDetails[] GetEmployees()
	{
		EmployeeDB db = new EmployeeDB();
		return db.GetEmployees();
	}

	[WebMethod()]
	public int GetEmployeesCountError()
	{
		try
		{
			SqlConnection con = new SqlConnection(connectionString);

			// Make a deliberately faulty SQL string
			string sql = "INVALID_SQL COUNT(*) FROM Employees";
			SqlCommand cmd = new SqlCommand(sql, con);

			// Open the connection and get the value.
			cmd.Connection.Open();
			int numEmployees = -1;
			try
			{
				numEmployees = (int)cmd.ExecuteScalar();
			}
			finally
			{
				cmd.Connection.Close();
			}
			return numEmployees;
		}
		catch (Exception err)
		{
			// Create the detail information
			// an <ExceptionType> element with the type name.
			XmlDocument doc = new XmlDocument();
			XmlNode node = doc.CreateNode(
				XmlNodeType.Element, SoapException.DetailElementName.Name,
				SoapException.DetailElementName.Namespace);
			XmlNode child = doc.CreateNode(
				XmlNodeType.Element, "ExceptionType",
				SoapException.DetailElementName.Namespace);
			child.InnerText = err.GetType().ToString();
			node.AppendChild(child);

			// Create the custom SoapException.
			// Use the message from the original exception,
			// and add the detail information.
			SoapException soapErr = new SoapException(
				err.Message, SoapException.ServerFaultCode,
				Context.Request.Url.AbsoluteUri, node);

			// Throw the revised SoapException.
			throw soapErr;
		}
	}
	private string connectionString;

	public EmployeesService()
	{
		connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
	}
}

