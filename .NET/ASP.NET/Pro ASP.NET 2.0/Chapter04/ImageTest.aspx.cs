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

public partial class ImageTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		lblResult.Text = "You clicked at (" + e.X.ToString() +
	     ", " + e.Y.ToString() + "). ";

		if ((e.Y < 100) && (e.Y > 20) && (e.X > 20) && (e.X < 275))
		{
			lblResult.Text += "You clicked on the button surface.";
		}
		else
		{
			lblResult.Text += "You clicked the button border.";
		}

	}
}
