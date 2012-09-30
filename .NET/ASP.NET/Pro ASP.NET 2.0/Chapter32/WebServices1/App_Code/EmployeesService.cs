using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Web.Configuration;

[WebService(Name = "Employees Service",
		 Description = "Retrieve the Northwind Employees",
		 Namespace = "http://www.apress.com/ProASP.NET/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class EmployeesService : System.Web.Services.WebService
{
	private string connectionString;

	public EmployeesService()
	{
		connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
	}

	[WebMethod(Description = "Returns the total number of employees.")]
	public int GetEmployeesCount()
	{
		// Create the command and the connection.	
		SqlConnection con = new SqlConnection(connectionString);
		string sql = "SELECT COUNT(*) FROM Employees";
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

	[WebMethod(Description = "Returns the full list of employees.")]
	public DataSet GetEmployees()
	{
		// Create the command and the connection.
		string sql = "SELECT EmployeeID, LastName, FirstName, Title, " +
			"TitleOfCourtesy, HomePhone FROM Employees";
		SqlConnection con = new SqlConnection(connectionString);
		SqlDataAdapter da = new SqlDataAdapter(sql, con);
		DataSet ds = new DataSet();

		// Fill the DataSet.
		da.Fill(ds, "Employees");
		return ds;
	}

	[WebMethod(Description = "Returns the full list of employees by city.",
		 MessageName = "GetEmployeesByCity")]
	public DataSet GetEmployeesByCity(string city)
	{
		// Create the command and the connection.
		string sql = "SELECT EmployeeID, LastName, FirstName, Title, " +
			"TitleOfCourtesy, HomePhone FROM Employees " +
			"WHERE City LIKE '%'+ @City + '%'";
		SqlConnection con = new SqlConnection(connectionString);
		SqlDataAdapter da = new SqlDataAdapter(sql, con);
		da.SelectCommand.Parameters.Add("@City", city);
		DataSet ds = new DataSet();

		// Fill the DataSet.
		da.Fill(ds, "Employees");
		return ds;
	}

	[WebMethod(Description = "Causes an error and returns a SOAP exception.")]
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
}
