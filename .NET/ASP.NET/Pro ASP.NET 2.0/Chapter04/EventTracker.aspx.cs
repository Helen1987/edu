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

public partial class EventTracker : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
    }

	protected void CtrlChanged(Object sender, EventArgs e)
	{
		string ctrlName = ((Control)sender).ID;
		lstEvents.Items.Add(ctrlName + " Changed");

		// Select the last item to scroll the list so the most recent
		// entries are visible.
		lstEvents.SelectedIndex = lstEvents.Items.Count - 1;
	}

}
