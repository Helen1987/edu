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

public partial class AdTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void AdRotator1_AdCreated(object sender, AdCreatedEventArgs e)
	{
		// Synchronize the Hyperlink control.
		lnkBanner.NavigateUrl = e.NavigateUrl;
		// Synchronize the text of the link.
		lnkBanner.Text = "Click here for information about our sponsor: ";
		lnkBanner.Text += e.AlternateText;
	}
}
