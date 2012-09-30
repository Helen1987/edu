using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using APress.ProAspNet.Utility;

public partial class _Asymmetric : System.Web.UI.Page 
{
    private string KeyFileName;

    protected void Page_Load(object sender, EventArgs e)
    {
        KeyFileName = Server.MapPath("~/") + "\\asymmetric_key.config";
    }

    protected void GenerateKeyCommand_Click(object sender, EventArgs e)
    {
        try
        {
            PublicKeyText.Text = AsymmetricEncryptionUtility.GenerateKey(KeyFileName);
            Response.Write("Key generated successfully!");
        }
        catch
        {
            Response.Write("Exception occured when encrypting key!");
        }
    }

    protected void EncryptCommand_Click(object sender, EventArgs e)
    {
        // Check for encryption key
        if (!File.Exists(KeyFileName))
        {
            Response.Write("Missing encryption key. Please generate key!");
        }

        try
        {
            byte[] data = AsymmetricEncryptionUtility.EncryptData(
                                ClearDataText.Text, PublicKeyText.Text);
            EncryptedDataText.Text = Convert.ToBase64String(data);
        }
        catch
        {
            Response.Write("Unable to encrypt data!");
        }
    }

    protected void DecryptCommand_Click(object sender, EventArgs e)
    {
        // Check for encryption key
        if (!File.Exists(KeyFileName))
        {
            Response.Write("Missing encryption key. Please generate key!");
        }

        try
        {
            byte[] data = Convert.FromBase64String(EncryptedDataText.Text);
            ClearDataText.Text = AsymmetricEncryptionUtility.DecryptData(data, KeyFileName);
        }
        catch
        {
            Response.Write("Unable to decrypt data!");
        }
    }

    protected void ClearCommand_Click(object sender, EventArgs e)
    {
        ClearDataText.Text = "";
        EncryptedDataText.Text = ""; 
    }
}