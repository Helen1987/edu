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

public partial class TemplatesAndConcurrency : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
	{
		if (e.AffectedRows == 0)
		{
			//lblStatus.Text = "No records were updated.";
			e.KeepInEditMode = true;

			// Allow more editing.
			detailsEditing.DataBind();

			// Re-populate DetailsView with values entered by user
			TextBox t;
			t = (TextBox)detailsEditing.Rows[1].Cells[1].Controls[0];
			t.Text = (string)e.NewValues["CompanyName"];
			t = (TextBox)detailsEditing.Rows[2].Cells[1].Controls[0];
			t.Text = (string)e.NewValues["Phone"];

			// Show the panel with errors.
			ErrorPanel.Visible = true;
		}
	}


	protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
	{
		if (!ErrorPanel.Visible) e.Cancel = true;
	}
}
