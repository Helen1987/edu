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

public partial class GridViewMasterDetails: System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
			  
	}
	protected void Page_PreRender(object sender, EventArgs e)
	{
		
	}


	protected void gridEmployees_SelectedIndexChanged(object sender, EventArgs e)
	{
		int index = gridEmployees.SelectedIndex;

		// You can retrieve the key field from the SelectedDataKey property.
		int ID = (int)gridEmployees.SelectedDataKey.Values["EmployeeID"];

		// You can retrieve other data directly from the Cells collection,
		// as long as you know the column offset.
		string firstName = gridEmployees.SelectedRow.Cells[2].Text;
		string lastName = gridEmployees.SelectedRow.Cells[3].Text;
		
		lblRegionCaption.Text = "Regions that " + firstName + " " + lastName +
			" (employee " + ID.ToString() + ") is responsible for:";
	}
}
