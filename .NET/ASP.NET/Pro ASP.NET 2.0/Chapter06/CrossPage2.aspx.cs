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

public partial class CrossPage2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (PreviousPage != null)
		{
			if (!PreviousPage.IsValid)
			{
				Response.Redirect(Request.UrlReferrer.AbsolutePath + "?err=true");
			}
			else
			{
				Response.Write("You came from a page titled " +
					 PreviousPage.Header.Title + "<br /");
				CrossPage1 prevPage = PreviousPage as CrossPage1;

				if (prevPage != null)
				{
					Response.Write("You typed in this: " + prevPage.TextBox1.Text + "<br />");
				}

				if (PreviousPage.IsCrossPagePostBack)
				{
					Response.Write("The page was posted directly");
				}
				else
				{
					Response.Write("You used Server.Transfer()");
				}
			}
		}
	}
}