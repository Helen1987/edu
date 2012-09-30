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

public partial class _Default : System.Web.UI.Page 
{
    private string KeyFileName;
    private string AlgorithmName = "DES";

    protected void Page_Load(object sender, EventArgs e)
    {
        SymmetricEncryptionUtility.AlgorithmName = AlgorithmName;
        KeyFileName = Server.MapPath("~/") + "\\symmetric_key.config";
    }

    protected void GenerateKeyCommand_Click(object sender, EventArgs e)
    {
        try
        {
            SymmetricEncryptionUtility.ProtectKey = EncryptKeyCheck.Checked;
            SymmetricEncryptionUtility.GenerateKey(KeyFileName);

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
            byte[] data = SymmetricEncryptionUtility.EncryptData(ClearDataText.Text, KeyFileName);
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
            ClearDataText.Text = SymmetricEncryptionUtility.DecryptData(data, KeyFileName);
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