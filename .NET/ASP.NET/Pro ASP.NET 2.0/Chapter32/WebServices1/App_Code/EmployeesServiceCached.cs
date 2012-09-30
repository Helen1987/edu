using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Data;



[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class EmployeesServiceCached : System.Web.Services.WebService
{

	private string connectionString = "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=SSPI";

	
	[WebMethod(Description = "Returns the full list of employees.")]
	public DataSet GetEmployees()
	{
		return GetEmployeesDataSet();
	}

	[WebMethod(Description = "Returns the full list of employees by city.")]
	public DataSet GetEmployeesByCity(string city)
	{
		// Copy the DataSet.
		DataSet dsFiltered = GetEmployeesDataSet().Copy();

		// Remove the rows manually.
		// This is a good approach (rather than using the
		// DataTable.Select() method) because it is impervious
		// to SQL injection attacks.
		foreach (DataRow row in dsFiltered.Tables[0].Rows)
		{
			// Perform a case-insensitive compare.
			if (String.Compare(row["City"].ToString(), city.ToUpper(), true) != 0)
			{
				row.Delete();
			}
		}

		// Remove these rows permanently.
		dsFiltered.AcceptChanges();

		return dsFiltered;
	}

	private DataSet GetEmployeesDataSet()
	{
		DataSet ds;

		if (Context.Cache["EmployeesDataSet"] != null)
		{
			// Retrieve it from the cache
			ds = (DataSet)Context.Cache["EmployeesDataSet"];
		}
		else
		{
			// Retrieve it from the database.
			string sql = "SELECT EmployeeID, LastName, FirstName, Title, " +
				"TitleOfCourtesy, HomePhone, City FROM Employees";
			SqlConnection con = new SqlConnection(connectionString);
			SqlDataAdapter da = new SqlDataAdapter(sql, con);
			ds = new DataSet();
			da.Fill(ds, "Employees");

			// Track when the DataSet was created. You can
			// retrieve this information in your client to test
			// that caching is working.
			ds.ExtendedProperties.Add("CreatedDate", DateTime.Now);

			// Store it in the cache for ten minutes.
			Context.Cache.Insert("EmployeesDataSet", ds, null,
			 DateTime.Now.AddMinutes(10), TimeSpan.Zero);
		}
		return ds;
	}
}

