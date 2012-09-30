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

public partial class SimpleDrawing : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Create the in-memory bitmap where you will draw the image. 
		// This bitmap is 300 pixels wide and 50 pixels high.
		Bitmap image = new Bitmap(300, 50);
		Graphics g = Graphics.FromImage(image);

		// Draw a solid white rectangle..
		// Start from point (1, 1).
		// Make it 298 pixels wide and 48 pixels high.
		g.FillRectangle(Brushes.White, 0, 0, 300, 50);
		g.DrawRectangle(Pens.Green, 0, 0, 299, 49);

		// Draw some text using a fancy font.
		Font font = new Font("Impact", 20, FontStyle.Regular);
		g.DrawString("This is a test.", font, Brushes.Blue, 10, 5);

        // Render the image to the HTML output stream.
        image.Save(Response.OutputStream,
            System.Drawing.Imaging.ImageFormat.Jpeg);

        g.Dispose();
        image.Dispose();
		

	}

}