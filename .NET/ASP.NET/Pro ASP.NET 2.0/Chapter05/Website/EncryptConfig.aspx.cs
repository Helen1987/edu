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

public partial class EncryptConfig : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Configuration config = WebConfigurationManager.OpenWebConfiguration(
  Request.ApplicationPath);
		ConfigurationSection appSettings = config.GetSection("appSettings");

		if (appSettings.SectionInformation.IsProtected)
		{
			appSettings.SectionInformation.UnprotectSection();
		}
		else
		{
			appSettings.SectionInformation.ProtectSection(
			  "DataProtectionConfigurationProvider");
		}
		config.Save();

	}
}
