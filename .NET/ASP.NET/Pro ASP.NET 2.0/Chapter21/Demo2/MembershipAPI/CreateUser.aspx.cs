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
using System.Diagnostics;

public partial class CreateUser : System.Web.UI.Page
{
    protected void ActionAddUser_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipCreateStatus Status;

            Membership.CreateUser(UserNameText.Text,
                                  PasswordText.Text,
                                  UserEmailText.Text,
                                  PwdQuestionText.Text,
                                  PwdAnswerText.Text, true,
                                  out Status);

            StatusLabel.Text = "User created successfully!";
        }
        catch(Exception ex)
        {
            Debug.WriteLine("Exception: " + ex.Message);
            StatusLabel.Text = "Unable to create user!";
        }
    }
}
