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

public partial class ProgrammaticOutputCaching : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Cache this page on the server.
		Response.Cache.SetCacheability(HttpCacheability.Public);

		// Use the cached copy of this page for the next 60 seconds.
		Response.Cache.SetExpires(DateTime.Now.AddSeconds(10));
		//Response.Cache.VaryByParams.IgnoreParams = true;

		// This additional line ensures that the browser can't
		// invalidate the page when the user clicks the Refresh button
		// (which some rogue browsers attempt to do).
		Response.Cache.SetValidUntilExpires(true);
		
		lblDate.Text = "The time is now:<br>" + DateTime.Now.ToString();

    }
}
