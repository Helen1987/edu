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

public partial class DynamicHeader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Page.Header.Title = "Dynamically Titled Page";
		
		// Not supported in beta2.
		//Page.Header.Metadata.Add("Keywords", ".NET, C#, ASP.NET");
		//Page.Header.Metadata.Add("Description", "A great website to learn .NET");

    }
}
