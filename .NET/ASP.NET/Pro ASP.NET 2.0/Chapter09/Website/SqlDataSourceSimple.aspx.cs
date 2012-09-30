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

public partial class SqlDataSourceSimple : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }
	protected void sourceEmployees_Selected(object sender, SqlDataSourceStatusEventArgs e)
	{
		if (e.Exception != null)
		{
			// Mask the error with a generic message (for security purposes.)
			lblError.Text = "An exception occured performing the query.";

			// Consider the error handled.
			e.ExceptionHandled = true;
		}
	}
}
