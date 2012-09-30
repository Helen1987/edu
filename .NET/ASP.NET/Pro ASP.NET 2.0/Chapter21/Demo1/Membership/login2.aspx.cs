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

public partial class login2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
            ViewState["LoginErrors"] = 0;
    }

    protected void LoginCtrl_LoginError(object sender, EventArgs e)
    {
        // Increase the number of invalid logins
        int ErrorCount = (int)ViewState["LoginErrors"] + 1;
        ViewState["LoginErrors"] = ErrorCount;
       
        // Now validate the number of errors
        if ((ErrorCount > 3) && (LoginCtrl.PasswordRecoveryUrl != string.Empty)) 
            Response.Redirect(LoginCtrl.PasswordRecoveryUrl);
    }
    
    protected void LoginCtrl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (Membership.ValidateUser(LoginCtrl.UserName, LoginCtrl.Password))
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
    }

    protected void OtherLoginCtrl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        TextBox AccessKeyText = (TextBox)OtherLoginCtrl.FindControl("AccessKey");

        if (Membership.ValidateUser(AccessKeyText.Text, OtherLoginCtrl.UserName))
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
    }
}
