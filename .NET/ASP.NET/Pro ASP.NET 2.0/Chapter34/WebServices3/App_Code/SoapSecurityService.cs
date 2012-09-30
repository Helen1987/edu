using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Security;
using System.Web.Configuration;


/// <summary>
/// Summary description for SoapSecurityService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SoapSecurityService : System.Web.Services.WebService
{
	// Store the SOAP header object.
	public TicketHeader Ticket;

	[WebMethod()]
	public void CreateTestUser(string username, string password)
	{
		try
		{
			if (Membership.GetUser(username) != null)
			{
				Membership.DeleteUser(username);
			}

			Membership.CreateUser(username, password);

			// Make this user an administrator.
			string role = "Administrator";
			if (!Roles.RoleExists(role))
			{
				Roles.CreateRole(role);
			}
			Roles.AddUserToRole(username, role);
		}
		catch (Exception err)
		{
			// Set a breakpoint here if needed for debugging.
			throw err;
		}
	}

	[WebMethod()]
	[SoapHeader("Ticket", Direction = SoapHeaderDirection.Out)]
	public void Login(string username, string password)
	{
		if (Membership.ValidateUser(username, password))
		{
			// Create a new ticket.
			TicketIdentity ticket = new TicketIdentity(username);

			// Add this ticket to Application state.
			Application[ticket.Ticket] = ticket;

			// Create the SOAP header.
			Ticket = new TicketHeader(ticket.Ticket);
		}
		else
		{
			throw new SecurityException("Invalid credentials.");
		}
	}

	[WebMethod(Description = "Returns the full list of employees.")]
	[SoapHeader("Ticket", Direction = SoapHeaderDirection.In)]
	public DataSet GetEmployees()
	{
		AuthorizeUser(Ticket.Ticket, "Administrator");

		string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
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

	private TicketIdentity AuthorizeUser(string ticket)
	{
		TicketIdentity ticketIdentity = (TicketIdentity)Application[ticket];
		if (ticket != null)
		{
			return ticketIdentity;
		}
		else
		{
			throw new SecurityException("Invalid ticket.");
		}
	}

	private TicketIdentity AuthorizeUser(string ticket, string role)
	{
		TicketIdentity ticketIdentity = AuthorizeUser(ticket);
		if (Roles.IsUserInRole(ticketIdentity.UserName, role))
		{
			return ticketIdentity;
		}
		else
		{
			throw new SecurityException("Insufficient permissions.");
		}
	}


}

public class TicketIdentity
{
	private string userName;
	public string UserName
	{
		get { return userName; }
	}

	private string ticket;
	public string Ticket
	{
		get { return ticket; }
	}

	public TicketIdentity(string userName)
	{
		this.userName = userName;

		// Create the ticket GUID.
		this.ticket = Guid.NewGuid().ToString();
	}
}

public class TicketHeader : SoapHeader
{
	public string Ticket;

	public TicketHeader(string ticket)
	{
		Ticket = ticket;
	}

	public TicketHeader()
	{ }
}

