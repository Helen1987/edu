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
using System.Web.Configuration;

public partial class Welcome_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
		
		lblSiteName.Text =
			config.AppSettings.Settings["websiteName"].Value;
		lblWelcome.Text =
			config.AppSettings.Settings["welcomeMessage"].Value;

		if (config.AppSettings.Settings["welcomeMessage"].Value.Length > 15)
		{
			config.AppSettings.Settings["welcomeMessage"].Value = "Welcome, again.";
		}
		else
		{
			config.AppSettings.Settings["welcomeMessage"].Value = "Welcome, friend.";
		}
		config.Save();
		
	}

}
