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

public partial class GridViewSummaries : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}


	protected void GridView1_DataBound(object sender, EventArgs e)
	{
		decimal valueInStock = 0;


		// The Rows collection only includes rows on the current page
		// (not "virtual" rows).
        foreach (GridViewRow row in GridView1.Rows)
        {
			decimal price = Decimal.Parse(row.Cells[2].Text.Substring(1));
			int unitsInStock = Int32.Parse(row.Cells[3].Text);
			valueInStock += price * unitsInStock;
        }

		GridViewRow footer = GridView1.FooterRow;
		
		// Set the first cell to span over the entire row.
		footer.Cells[0].ColumnSpan = 3;
		footer.Cells[0].HorizontalAlign = HorizontalAlign.Center;

		// Remove the unneeded cells.
		footer.Cells.RemoveAt(2);
		footer.Cells.RemoveAt(1);

		// Add the text.
		footer.Cells[0].Text = "Total value in stock (on this page): " +
		  valueInStock.ToString("C");

	}
	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{

	}
	protected void GridView1_DataBinding(object sender, EventArgs e)
	{


	}
}
