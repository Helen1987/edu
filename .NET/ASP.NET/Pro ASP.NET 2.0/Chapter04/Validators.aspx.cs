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

public partial class Validators : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void Submit_Click(object sender, EventArgs e)
	{
		if (Page.IsValid)
			Result.Text = "Thanks for sending your data";
		else
			Result.Text = "There are some errors, please correct them and re-send the form.";
	}
	protected void OptionsChanged(object sender, EventArgs e)
	{
		foreach (BaseValidator valCtl in Page.Validators)
		{
			valCtl.Enabled = EnableValidators.Checked;
			valCtl.EnableClientScript = EnableClientSide.Checked;
		}
		ValidationSum.ShowMessageBox = ShowMsgBox.Checked;
		ValidationSum.ShowSummary = ShowSummary.Checked;
	}
	protected void ValidateEmpID2_ServerValidate(object source, ServerValidateEventArgs args)
	{
		try
		{
			args.IsValid = (int.Parse(args.Value) % 5 == 0);
		}
		catch
		{
			args.IsValid = false;
		}
	}
}
