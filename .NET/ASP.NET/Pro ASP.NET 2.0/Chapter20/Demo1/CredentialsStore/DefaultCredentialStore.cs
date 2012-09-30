using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DefaultCredentialStore
/// </summary>
namespace CredentialStoreNamespace
{
    public class WebConfigCredentialStore : ICredentialStore
    {
        public bool Authenticate(string userName, string userPassword)
        {
            return FormsAuthentication.Authenticate(userName, userPassword);
        }

        public void CreateUser(string userName, string userPassword)
        {
            Configuration MyConfig = WebConfigurationManager.OpenWebConfiguration("~/");

            ConfigurationSectionGroup SystemWeb = MyConfig.SectionGroups["system.web"];
            AuthenticationSection AuthSec = (AuthenticationSection)SystemWeb.Sections["authentication"];
            AuthSec.Forms.Credentials.Users.Add(
                new FormsAuthenticationUser(userName, 
                        FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1")));

            MyConfig.Save();
        }
    }
}
