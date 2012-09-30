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

public partial class login : System.Web.UI.Page
{
    protected void LoginAction_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid) return;
            
        if (FormsAuthentication.Authenticate(UsernameText.Text, PasswordText.Text))
        {
            // Create the ticket, add the cookie to the response
            // and redirect to the originally requested page
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, false);
        }
        else
        {
            // Username and password are not correct
            LegendStatus.Text = "Invalid username or password!";
        }
    }
}
