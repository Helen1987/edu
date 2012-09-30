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

public partial class SqlDataSourceUpdate2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			  
    }
	protected void sourceEmployees_Selected(object sender, SqlDataSourceStatusEventArgs e)
	{

	}
	protected void sourceEmployees_Updating(object sender, SqlDataSourceCommandEventArgs e)
	{
		e.Command.Parameters["@First"].Value = e.Command.Parameters["@FirstName"].Value;
		e.Command.Parameters["@Last"].Value = e.Command.Parameters["@LastName"].Value;
		e.Command.Parameters.Remove(e.Command.Parameters["@FirstName"]);
		e.Command.Parameters.Remove(e.Command.Parameters["@LastName"]);

	}
}
