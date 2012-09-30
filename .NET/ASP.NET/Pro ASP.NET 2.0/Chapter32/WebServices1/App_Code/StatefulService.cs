using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// Summary description for StatefulService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class StatefulService : System.Web.Services.WebService
{
	[WebMethod(EnableSession = true)]
	public void StoreName(string name)
	{
		Session["Name"] = name;
	}

	[WebMethod(EnableSession = true)]
	public string GetName()
	{
		if (Session["Name"] == null)
		{
			return "";
		}
		else
		{
			return (string)Session["Name"];
		}
	}
}

