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

public partial class ControlTree : System.Web.UI.Page
{
	private void Page_Load(object sender, System.EventArgs e)
	{
		// Start examining all the controls.
		DisplayControl(Page.Controls, 0);

		// Add the closing horizontal line.
		Response.Write("<hr/>");
	}

	private void DisplayControl(ControlCollection controls, int depth)
	{
		foreach (Control control in controls)
		{
			// Use the depth parameter to indent the control tree.
			Response.Write(new String('-', depth * 4) + "> ");

			// Display this control.
			Response.Write(control.GetType().ToString() + " - <b>" +
			  control.ID + "</b><br/>");

			if (control.Controls != null)
			{
				DisplayControl(control.Controls, depth + 1);
			}
		}
	}

}
