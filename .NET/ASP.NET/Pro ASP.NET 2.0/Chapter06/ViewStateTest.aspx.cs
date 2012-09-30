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

public partial class ViewStateTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void cmdSave_Click(object sender, EventArgs e)
	{
		// Save the current text.
		SaveAllText(Page.Controls, true);
	}

	private void SaveAllText(ControlCollection controls, bool saveNested)
	{
		foreach (Control control in controls)
		{
			if (control is TextBox)
			{
				// Store the text using the unique control ID.
				ViewState[control.ID] = ((TextBox)control).Text;
			}

			if ((control.Controls != null) && saveNested)
			{
				SaveAllText(control.Controls, true);
			}
		}
	}

	private void RestoreAllText(ControlCollection controls, bool saveNested)
	{
		foreach (Control control in controls)
		{
			if (control is TextBox)
			{
				if (ViewState[control.ID] != null)
					((TextBox)control).Text = (string)ViewState[control.ID];
			}

			if ((control.Controls != null) && saveNested)
			{
				RestoreAllText(control.Controls, true);
			}
		}
	}
	protected void cmdRestore_Click(object sender, EventArgs e)
	{

		// Retrieve the last saved text.
		RestoreAllText(Page.Controls, true);
	}
}
