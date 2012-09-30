using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DbLogin : System.Web.UI.Page
{
    private bool MyAuthenticate(string username, string userPassword)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyLoginDb"].ConnectionString;

        conn.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT UserName From MyUsers " +
                              "WHERE UserName=@usr AND UserPassword=@pwd";
            cmd.Parameters.AddWithValue("@usr", username);
            cmd.Parameters.AddWithValue("@pwd", userPassword);

            string RetUser = (string)cmd.ExecuteScalar();
            if (RetUser != null)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            // Log the error but don't 
            // display any details to the user
            System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            // Login failed
            return false;
        }
        finally
        {
            conn.Close();
        }
    }

    protected void LoginAction_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid) return;

        if (this.MyAuthenticate(UsernameText.Text, PasswordText.Text))
        {
            FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, false);
        }
        else
        {
            LegendStatus.Text = "Invalid username or password!";
        }
    }
}
