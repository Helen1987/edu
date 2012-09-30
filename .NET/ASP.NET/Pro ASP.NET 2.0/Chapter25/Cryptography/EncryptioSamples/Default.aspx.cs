using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using APress.ProAspNet.Utility;

public partial class _Default : System.Web.UI.Page 
{
    SqlConnection DemoDb;

    private TextBox CreditCardText;
    private TextBox StreetText;
    private TextBox ZipCodeText;
    private TextBox CityText;

    private string EncryptionKeyFile;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Configure Encryption Utility
        EncryptionKeyFile = Server.MapPath("key.config");
        SymmetricEncryptionUtility.AlgorithmName = "DES";
        if (!System.IO.File.Exists(EncryptionKeyFile))
        {
            SymmetricEncryptionUtility.GenerateKey(EncryptionKeyFile);
        }

        // Create the connection
        DemoDb = new SqlConnection(
            ConfigurationManager.ConnectionStrings["DemoSql"].ConnectionString);

        // Associate with Textfields
        CreditCardText = (TextBox)MainLoginView.FindControl("CreditCardText");
        StreetText = (TextBox)MainLoginView.FindControl("StreetText");
        ZipCodeText = (TextBox)MainLoginView.FindControl("ZipCodeText");
        CityText = (TextBox)MainLoginView.FindControl("CityText");
    }

    protected void LoadCommand_Click(object sender, EventArgs e)
    {
        DemoDb.Open();

        try
        {
            string SqlText = "SELECT * FROM ShopInfo WHERE UserId=@key";
            SqlCommand Cmd = new SqlCommand(SqlText, DemoDb);
            Cmd.Parameters.AddWithValue("@key", Membership.GetUser().ProviderUserKey);
            using (SqlDataReader Reader = Cmd.ExecuteReader())
            {
                if (Reader.Read())
                {
                    // Cleartext Data
                    StreetText.Text = Reader["City"].ToString();
                    ZipCodeText.Text = Reader["ZipCode"].ToString();
                    CityText.Text = Reader["City"].ToString();

                    // Encrypted Data
                    byte[] SecretCard = (byte[])Reader["CreditCard"];
                    CreditCardText.Text = 
                        SymmetricEncryptionUtility.DecryptData(
                                    SecretCard, EncryptionKeyFile);
                }
            }
        }
        finally
        {
            DemoDb.Close();
        }
    }

    protected void SaveCommand_Click(object sender, EventArgs e)
    {
        DemoDb.Open();

        try
        {
            string SqlText = "UPDATE ShopInfo " + 
                             "SET Street=@street, ZipCode=@zip, " +
                                 "City=@city, CreditCard=@card " +
                             "WHERE UserId=@key";

            SqlCommand Cmd = new SqlCommand(SqlText, DemoDb);
            
            // Add simple values
            Cmd.Parameters.AddWithValue("@street", StreetText.Text);
            Cmd.Parameters.AddWithValue("@zip", ZipCodeText.Text);
            Cmd.Parameters.AddWithValue("@city", CityText.Text);
            Cmd.Parameters.AddWithValue("@key", Membership.GetUser().ProviderUserKey);
            
            // Now add the encrypted value
            byte[] EncryptedData = 
                SymmetricEncryptionUtility.EncryptData(
                        CreditCardText.Text, EncryptionKeyFile);
            Cmd.Parameters.AddWithValue("@card", EncryptedData);

            // Execute the command
            int results = Cmd.ExecuteNonQuery();
            if (results == 0)
            {
                Cmd.CommandText = "INSERT INTO ShopInfo VALUES(@key, @card, @street, @zip, @city)";
                Cmd.ExecuteNonQuery();
            }
        }
        finally
        {
            DemoDb.Close();
        }
    }
}