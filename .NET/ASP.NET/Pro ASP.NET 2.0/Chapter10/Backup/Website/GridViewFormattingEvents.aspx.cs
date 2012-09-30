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

public partial class GridViewFormattingEvents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
    }

	protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			// Get the title of courtesy for the item that's being created.
			string title = (string)DataBinder.Eval(e.Row.DataItem, "TitleOfCourtesy");

			// If the title of courtesy is "Ms.", "Mrs.", or "Mr.",
			// change the item's colors.
			if (title == "Ms." || title == "Mrs.")
			{
				e.Row.BackColor = System.Drawing.Color.LightPink;
				e.Row.ForeColor = System.Drawing.Color.Maroon;
			}
			else if (title == "Mr.")
			{
				e.Row.BackColor = System.Drawing.Color.LightCyan;
				e.Row.ForeColor = System.Drawing.Color.DarkBlue;
			}
		}

	}
}
