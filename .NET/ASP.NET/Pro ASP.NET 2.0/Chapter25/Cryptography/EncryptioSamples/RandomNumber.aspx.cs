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

using System.Security.Cryptography;

public partial class RandomNumber : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void RandomNumberCommand_Click(object sender, EventArgs e)
    {
        byte[] RandomValue = new byte[16];
        RandomNumberGenerator RndGen = RandomNumberGenerator.Create();
        RndGen.GetBytes(RandomValue);
        ResultLabel.Text = Convert.ToBase64String(RandomValue);
    }
}
