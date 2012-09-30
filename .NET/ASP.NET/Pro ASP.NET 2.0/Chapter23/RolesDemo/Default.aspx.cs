using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            RolePrincipal rp = (RolePrincipal)User;

            StringBuilder RoleInfo = new StringBuilder();
            RoleInfo.AppendFormat("<h2>Welcome {0}</h2>", rp.Identity.Name);
            RoleInfo.AppendFormat("<b>Provider:</b> {0}<BR>", rp.ProviderName);
            RoleInfo.AppendFormat("<b>Version:</b> {0}<BR>", rp.Version);
            RoleInfo.AppendFormat("<b>Expires at:</b> {0}<BR>", rp.ExpireDate);
            RoleInfo.Append("<b>Roles:</b> ");

            string[] roles = rp.GetRoles();
            for (int i = 0; i < roles.Length; i++)
            {
                if (i > 0) RoleInfo.Append(", ");
                RoleInfo.Append(roles[i]);
            }

            LabelRoleInformation.Text = RoleInfo.ToString();
        }
    }
}