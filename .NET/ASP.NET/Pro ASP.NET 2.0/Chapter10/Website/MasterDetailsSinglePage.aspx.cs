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

public partial class MasterDetailsSinglePage : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void gridMaster_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		// Look for GridView items.
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			// Retrieve the GridView control in the second column.
			GridView gridChild = (GridView)e.Row.Cells[1].Controls[1];

			sourceProducts.SelectParameters[0].DefaultValue = gridMaster.DataKeys[e.Row.DataItemIndex].Value.ToString();
			object data = sourceProducts.Select(DataSourceSelectArguments.Empty);
			
			// Bind the grid.
			gridChild.DataSource = data;
			gridChild.DataBind();
			

		}
	}
}
