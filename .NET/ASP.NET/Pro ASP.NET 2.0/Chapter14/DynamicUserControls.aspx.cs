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

public partial class DynamicUserControls : System.Web.UI.Page
{

	protected void Page_Load(object sender, System.EventArgs e)
	{
		LoadControls(div1);
		LoadControls(div2);
		LoadControls(div3);
	}

	private void LoadControls(Control container)
	{
		DropDownList list = null;
		PlaceHolder ph = null;
		Label lbl = null;

		// Find the controls for this panel.
		foreach (Control ctrl in container.Controls)
		{
			if (ctrl is DropDownList)
			{
				list = (DropDownList)ctrl;
			}
			else if (ctrl is PlaceHolder)
			{
				ph = (PlaceHolder)ctrl;
			}
			else if (ctrl is Label)
			{
				lbl = (Label)ctrl;
			}
		}

		// Load the dynamic content into this panel.
		string ctrlName = list.SelectedItem.Value;
		if (ctrlName.EndsWith(".ascx"))
		{
			ph.Controls.Add(Page.LoadControl(ctrlName));
		}
		lbl.Text = "Loaded..." + ctrlName;
	}

}
