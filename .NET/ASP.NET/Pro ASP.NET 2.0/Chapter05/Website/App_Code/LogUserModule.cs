using System;
using System.Web;
using System.Diagnostics;


public class LogUserModule : IHttpModule
{
	public void Init(HttpApplication httpApp)
	{
		// Attach application event handlers.
		httpApp.AuthenticateRequest += new EventHandler(OnAuthentication);
	}

	private void OnAuthentication(object sender, EventArgs a)
	{
		// Get the current user identity.
		string name = HttpContext.Current.User.Identity.Name;

		// Log the user name.
		EventLog log = new EventLog();
		log.Source = "Log User Module";
		log.WriteEntry(name + " was authenticated.");
	}

	public void Dispose()
	{ }
}
