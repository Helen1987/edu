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

public partial class LoginPersist : System.Web.UI.Page
{
    protected void LoginAction_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid) return;
            
        if (FormsAuthentication.Authenticate(UsernameText.Text, PasswordText.Text))
        {
            // Create the authentication cookie
            HttpCookie AuthCookie;
            AuthCookie = FormsAuthentication.GetAuthCookie(UsernameText.Text, true);
            AuthCookie.Expires = DateTime.Now.AddMinutes(5);
            
            // Add the cookie to the response
            Response.Cookies.Add(AuthCookie);

            // Redirect to the originally requested page
            Response.Redirect(FormsAuthentication.GetRedirectUrl(UsernameText.Text, true));
        }
        else
        {
            // Username and password are not correct
            LegendStatus.Text = "Invalid username or password!";
        }
    }
}
