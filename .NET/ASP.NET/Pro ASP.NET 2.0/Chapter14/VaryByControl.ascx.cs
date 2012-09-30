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

public partial class VaryByControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
		switch (lstMode.SelectedIndex)
		{
			case 0:
				TimeMsg.Font.Size = FontUnit.Large;
				break;
			case 1:
				TimeMsg.Font.Size = FontUnit.Small;
				break;
			case 2:
				TimeMsg.Font.Size = FontUnit.Medium;
				break;
		}
		TimeMsg.Text = DateTime.Now.ToString("F");
    }
	protected void SubmitBtn_Click(object sender, EventArgs e)
	{
		

	}
}
