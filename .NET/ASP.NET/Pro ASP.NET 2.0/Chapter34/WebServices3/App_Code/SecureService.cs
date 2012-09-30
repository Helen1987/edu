using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// Summary description for SecureService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SecureService : System.Web.Services.WebService
{

	[WebMethod()]
	public string TestAuthenticated()
	{
		if (!User.Identity.IsAuthenticated)
		{
			return "Not authenticated.";
		}
		else
		{
			return "Authenticated as: " + User.Identity.Name;
		}
	}

}

