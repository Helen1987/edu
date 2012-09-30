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

public partial class GridViewTemplate : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
			  
	}
	protected void Page_PreRender(object sender, EventArgs e)
	{
		
	}

	protected string[] TitlesOfCourtesy
	{
		get
		{
			return new string[] { "Mr.", "Dr.", "Ms.", "Mrs." };
		}
	}
	protected int GetSelectedTitle(object title)
	{
		return Array.IndexOf(TitlesOfCourtesy, title.ToString());
	}

	protected void gridEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		// Get the ID of the record to update.
		//int empID = (int)gridEmployees.DataKeys.[e.RowIndex];
    		
		// Get the reference to the list control.
		DropDownList title = (DropDownList)(gridEmployees.Rows[e.RowIndex].FindControl("EditTitle"));

		// Add it to the parameters.
		e.NewValues.Add("TitleOfCourtesy", title.Text);
	}
}
