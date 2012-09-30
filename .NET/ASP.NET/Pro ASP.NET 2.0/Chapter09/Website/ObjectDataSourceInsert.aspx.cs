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

public partial class ObjectDataSourceInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
			  
    }
	protected void Page_PreRender(object sender, EventArgs e)
	{
	}
	protected void sourceEmployees_Updating(object sender, ObjectDataSourceMethodEventArgs e)
	{
		
//set extra params
		//e.InputParameters["FirstName"] = "A";
	}

	protected void sourceEmployees_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
	{
		if (e.Exception == null)
		{
			lblConfirmation.Text = "Inserted record " + e.ReturnValue.ToString();
		}
	}
}
