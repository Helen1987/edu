using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


public partial class CreateChart : System.Web.UI.Page
{

	// The data that will be used to create the pie chart.
	private ArrayList pieSlices = new ArrayList();

	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Retrieve the pie slices that are defined so far.
		if (Session["ChartData"] != null)
		{
			pieSlices = (ArrayList)Session["ChartData"];
		}
	}

	protected void cmdAdd_Click(object sender, System.EventArgs e)
	{
		// Create a new pie slice.
		PieSlice pieSlice = new PieSlice(txtLabel.Text, Single.Parse(txtValue.Text));
		pieSlices.Add(pieSlice);

		// Bind the list box to the new data.
		lstPieSlices.DataSource = pieSlices;
		lstPieSlices.DataBind();
	}

	protected void CreateChart_PreRender(object sender, System.EventArgs e)
	{
		// Before rendering the page, store the current collection
		// of pie slices.
		Session["ChartData"] = pieSlices;
	}
}
