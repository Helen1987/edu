using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;

namespace GDI_CustomControls
{
	public class GradientLabel : Control
	{
		public GradientLabel()
		{
			Text = "";
			TextColor = Color.White;
			GradientColorA = Color.Blue;
			GradientColorB = Color.DarkBlue;
			TextSize = 14;
		}
		
		public string Text
		{
			get
			{
				return (string)ViewState["Text"];
			}
			set
			{
				ViewState["Text"] = value;
			}
		}

		public int TextSize
		{
			get
			{
				return (int)ViewState["TextSize"];
			}
			set
			{
				ViewState["TextSize"] = value;
			}
		}

		public Color GradientColorA
		{
			get
			{
				return (Color)ViewState["ColorA"];
			}
			set
			{
				ViewState["ColorA"] = value;
			}
		}

		public Color GradientColorB
		{
			get
			{
				return (Color)ViewState["ColorB"];
			}
			set
			{
				ViewState["ColorB"] = value;
			}
		}

		public Color TextColor
		{
			get
			{
				return (Color)ViewState["TextColor"];
			}
			set
			{
				ViewState["TextColor"] = value;
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			HttpContext context = HttpContext.Current;
			writer.Write("<img src='" + "GradientLabel.aspx?" +
				"Text=" + context.Server.UrlEncode(Text) +
				"&TextSize=" + TextSize.ToString() + 
				"&TextColor=" + TextColor.ToArgb() + 
				"&GradientColorA=" + GradientColorA.ToArgb() + 
				"&GradientColorB=" + GradientColorB.ToArgb() + 
				"'>");
		}

	}
}
