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
using System.Text;

public partial class WizardTemplates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append("You chose: <br />");
		sb.Append("Programming Language: ");
		sb.Append(lstLanguage.Text);
		sb.Append("<br />Total Employees: ");
		sb.Append(txtEmpCount.Text);
		sb.Append("<br />Total Locations: ");
		sb.Append(txtLocCount.Text);
		sb.Append("<br />Licenses Required: ");
		foreach (ListItem item in lstTools.Items)
		{
			if (item.Selected)
			{
				sb.Append(item.Text);
				sb.Append(" ");
			}
		}
		lblSummary.Text = sb.ToString();
	}
}
