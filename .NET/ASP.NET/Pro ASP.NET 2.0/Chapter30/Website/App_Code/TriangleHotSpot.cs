using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CustomHotSpots
{
	public class TriangleHotSpot : HotSpot
	{
		public TriangleHotSpot()
		{
			Width = 0;
			Height = 0;
			X = 0;
			Y = 0;
		}

		public int Width
		{
			get { return (int)ViewState["Width"]; }
			set { ViewState["Width"] = value; }
		}
		public int Height
		{
			get { return (int)ViewState["Height"]; }
			set { ViewState["Height"] = value; }
		}
		public int X
		{
			get { return (int)ViewState["X"]; }
			set { ViewState["X"] = value; }
		}
		public int Y
		{
			get { return (int)ViewState["Y"]; }
			set { ViewState["Y"] = value; }
		}

		protected override string MarkupName
		{
			get { return "poly"; }
		}

		public override string GetCoordinates()
		{
			// Note that this triangle doesn't support rotation.

			// Top coordinate.
			int topX = X;
			int topY = Y - Height / 2;

			// Bottom-left coordinate.
			int btmLeftX = X - Width / 2;
			int btmLeftY = Y + Height / 2;

			// Bottom-right coordinate.
			int btmRightX = X + Width / 2;
			int btmRightY = Y + Height / 2;

			return topX.ToString() + "," + topY.ToString() + "," +
				btmLeftX.ToString() + "," + btmLeftY.ToString() + "," +
				btmRightX.ToString() + "," + btmRightY.ToString();
		}
	}
}