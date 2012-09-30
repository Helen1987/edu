using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((User != null) && (User.Identity.IsAuthenticated))
        {
            RolePrincipal rp = (RolePrincipal)User;

            StringBuilder Info = new StringBuilder();
            Info.AppendFormat("<h2>Welcome {0}!</h2>", User.Identity.Name);
            Info.AppendFormat("<b>Provider: </b>{0}<br>", rp.ProviderName);
            Info.AppendFormat("<b>Version: </b>{0}<br>", rp.Version);
            Info.AppendFormat("<b>Expiration: </b>{0}<br>", rp.ExpireDate);
            Info.AppendFormat("<b>Roles: </b><br>");

            string[] Roles = rp.GetRoles();
            foreach (string role in Roles)
            {
                if (!role.Equals(string.Empty))
                    Info.AppendFormat("-) {0}<br>", role);
            }

            LabelPrincipalInfo.Text = Info.ToString();
        }
    }
}