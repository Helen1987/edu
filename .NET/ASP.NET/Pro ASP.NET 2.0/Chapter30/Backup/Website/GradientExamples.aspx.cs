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
using System.IO;


public partial class GradientExamples : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the in-memory bitmap where you will draw the image. 
		Bitmap image = new Bitmap(300, 300);
		Graphics g = Graphics.FromImage(image);

		// Paint the background.
		g.FillRectangle(Brushes.White, 0, 0, 300, 300);

		// Create a brush to use.
		LinearGradientBrush myBrush;

		// Create variable to track the coordinates in the image.
		int y = 20;
		int x = 20;

		// Show a rectangle with each type of gradient.
		foreach (LinearGradientMode gradientStyle in System.Enum.GetValues(typeof(LinearGradientMode)))
		{
			myBrush = new LinearGradientBrush(new Rectangle(x, y, 100, 60), Color.Violet, Color.White, gradientStyle);
			g.FillRectangle(myBrush, x, y, 100, 60);
			g.DrawString(gradientStyle.ToString(), new Font("Tahoma", 8), Brushes.Black, 110 + x, y + 20);
			y += 70;
		}

		// Render the image to the HTML output stream.
		image.Save(Response.OutputStream,
			System.Drawing.Imaging.ImageFormat.Jpeg);

		g.Dispose();
		image.Dispose();
	}

}