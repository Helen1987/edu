using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DatabaseCredentialStore
/// </summary>

namespace CredentialStoreNamespace
{
    public class DatabaseCredentialStore : ICredentialStore
    {
        private SqlConnection conn;

        public DatabaseCredentialStore()
        {
            conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["MyLoginDb"].ConnectionString;
        }

        public bool Authenticate(string userName, string userPassword, out string userData)
        {
            userData = string.Empty;

            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT UserEmail From MyUsers " +
                                  "WHERE UserName=@usr AND UserPassword=@pwd";
                cmd.Parameters.AddWithValue("@usr", userName);
                cmd.Parameters.AddWithValue("@pwd", 
                    FormsAuthentication.HashPasswordForStoringInConfigFile(
                                userPassword, "SHA1"));

                userData = (string)cmd.ExecuteScalar();
                if (userData != null)
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

        public void CreateUser(string userName, string userPassword, string userData)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO MyUsers VALUES(@usr, @pwd, @email)";
                cmd.Parameters.AddWithValue("@usr", userName);
                cmd.Parameters.AddWithValue("@pwd", 
                    FormsAuthentication.HashPasswordForStoringInConfigFile(userPassword, "SHA1"));
                cmd.Parameters.AddWithValue("@email", userData);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log the error but don't 
                // display any details to the user
                System.Diagnostics.Debug.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}