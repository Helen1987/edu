using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Web.Configuration;
using Microsoft.Web.Services3.Security.Tokens;
using Microsoft.Web.Services3;
using System.Security;

/// <summary>
/// Summary description for EmployeesService
/// </summary>
[WebService(Name = "Employees Service",
		 Description = "Retrieve the Northwind Employees",
		 Namespace = "http://www.apress.com/ProASP.NET/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class EmployeesService : System.Web.Services.WebService
{
	[SoapLog(Name = "EmployeesService.GetEmployeesLogged", Level = 3)]
	[WebMethod()]
	public DataSet GetEmployeesLogged()
	{
		return GetEmployees();
	}

	[WebMethod()]
	public DataSet GetEmployeesSlow()
	{
		// Delay.
		System.Threading.Thread.Sleep(4000);

		return GetEmployees();
	}

	[WebMethod()]
	public DataSet GetEmployeesWseSecured()
	{
		GetUsernameToken();
		return GetEmployees();
	}

	private DataSet GetEmployees()
	{
		string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

		// Create the command and the connection.
		string sql = "SELECT * FROM Employees";
		SqlConnection con = new SqlConnection(connectionString);

		SqlCommand cmd = new SqlCommand("GetAllEmployees", con);
		cmd.CommandType = CommandType.StoredProcedure;
		SqlDataAdapter da = new SqlDataAdapter(cmd);
		DataSet ds = new DataSet();

		// Fill the DataSet.
		da.Fill(ds, "Employees");
		return ds;
	}

	private string GetUsernameToken()
	{
		
		foreach (SecurityToken token in RequestSoapContext.Current.Security.Tokens)
		{
			if (token is UsernameToken)
				return ((UsernameToken)token).Username;
			if (token is IssuedToken)
				return "";

		}
		throw new SecurityException("Missing security token");
	}

}



