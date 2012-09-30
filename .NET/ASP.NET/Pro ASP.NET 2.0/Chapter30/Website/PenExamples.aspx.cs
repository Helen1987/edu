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
using System.Drawing.Drawing2D;


public partial class PenExamples : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the in-memory bitmap where you will draw the image. 
		// This bitmap is 300 pixels wide and 50 pixels high.
		Bitmap image = new Bitmap(500, 400);
		Graphics g = Graphics.FromImage(image);

		// Paint the background.
		g.FillRectangle(Brushes.White, 0, 0, 500, 400);

		// Create a pen to use for all the examples.
		Pen myPen = new Pen(Color.Blue, 10);

		// The y variable tracks the current y (up/down) position
		// in the image.
		int y = 60;

		// Draw an example of each LineCap style in the first column (left).
		g.DrawString("LineCap Choices", new Font("Tahoma", 15, FontStyle.Bold), Brushes.Blue, 0, 10);
		foreach (LineCap cap in System.Enum.GetValues(typeof(LineCap)))
		{
			myPen.StartCap = cap;
			myPen.EndCap = cap;
			g.DrawLine(myPen, 20, y, 100, y);
			g.DrawString(cap.ToString(), new Font("Tahoma", 8), Brushes.Black, 120, y - 10);
			y += 30;
		}


		// Draw an example of each DashStyle in the second column (right).
		y = 60;
		g.DrawString("DashStyle Choices", new Font("Tahoma", 15, FontStyle.Bold), Brushes.Blue, 200, 10);
		foreach (DashStyle dash in System.Enum.GetValues(typeof(DashStyle)))
		{
			myPen.DashStyle = dash;
			g.DrawLine(myPen, 220, y, 300, y);
			g.DrawString(dash.ToString(), new Font("Tahoma", 8), Brushes.Black, 320, y - 10);
			y += 30;
		}
		// Render the image to the HTML output stream.
		image.Save(Response.OutputStream,
			System.Drawing.Imaging.ImageFormat.Gif);

		g.Dispose();
		image.Dispose();
	}

}
