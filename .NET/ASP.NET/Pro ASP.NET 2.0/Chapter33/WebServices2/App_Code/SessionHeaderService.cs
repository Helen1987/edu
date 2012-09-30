using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;


/// <summary>
/// Summary description for SessionHeaderService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SessionHeaderService : System.Web.Services.WebService
{
	public SessionHeader CurrentSessionHeader;

	[WebMethod()]
	[SoapHeader("CurrentSessionHeader", Direction = SoapHeaderDirection.Out)]
	public void CreateSession()
	{
		// Create the header.
		CurrentSessionHeader = new SessionHeader(Guid.NewGuid().ToString());

		// From now on, all session data will be indexed under that key.
		Application[CurrentSessionHeader.SessionID] = new Hashtable();
	}

	[WebMethod()]
	[SoapHeader("CurrentSessionHeader", Direction = SoapHeaderDirection.In)]
	public void SetSessionData(DataSet ds)
	{
		// Locking is not required, because no two clients
		// could share the same session ID.
		Hashtable session = (Hashtable)Application[CurrentSessionHeader.SessionID];
		session.Add("DataSet", ds);
	}

	[WebMethod()]
	[SoapHeader("CurrentSessionHeader", Direction = SoapHeaderDirection.In)]
	public DataSet GetSessionData()
	{
		Hashtable session = (Hashtable)Application[CurrentSessionHeader.SessionID];
		return (DataSet)session["DataSet"];
	}

}

public class SessionHeader : SoapHeader
{
	public string SessionID;

	public SessionHeader(string sessionID)
	{
		SessionID = sessionID;
	}
	// Default constructor is required for serialization.
	public SessionHeader()
	{ }
}