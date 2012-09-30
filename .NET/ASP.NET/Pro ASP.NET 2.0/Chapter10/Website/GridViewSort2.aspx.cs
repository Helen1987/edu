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

public partial class GridViewSort2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
			  
	}
	protected void Page_PreRender(object sender, EventArgs e)
	{
		
	}


	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		// Save selected index
		if (GridView1.SelectedIndex != -1)
		{
			ViewState["SelectedValue"] = GridView1.SelectedValue.ToString();
		}

	}
	protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
	{
		// Clear selection.
		GridView1.SelectedIndex = -1;

		
		if (GridView1.SortExpression.StartsWith(e.SortExpression))
		{
			// This sort is being applied to the same field for the second time.
			// Reverse it.
			if (GridView1.SortDirection == SortDirection.Ascending)
			{
				//e.SortExpression += " DESC";
				e.SortDirection = SortDirection.Descending;
			}

		}
		

	}
	protected void GridView1_DataBound(object sender, EventArgs e)
	{
		String selectedValue = (String)ViewState["SelectedValue"];
		if (selectedValue == null)
		{
			return;
		}

		// Determine if the selected row is visible and re-select it
		foreach (GridViewRow row in GridView1.Rows)
		{
			String keyValue = GridView1.DataKeys[row.RowIndex].Value.ToString();
			if (keyValue == selectedValue)
			{
				GridView1.SelectedIndex = row.RowIndex;
			}
		}

	}
	protected void lstSorts_SelectedIndexChanged(object sender, EventArgs e)
	{
		GridView1.Sort(lstSorts.SelectedValue, SortDirection.Ascending);
	}
}
