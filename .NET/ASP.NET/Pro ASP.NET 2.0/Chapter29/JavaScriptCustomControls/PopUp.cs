using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace CustomServerControlsLibrary
{
	/// <summary>
	/// Summary description for PopUp.
	/// </summary>
	public class PopUp : Control
	{
		public PopUp()
		{
			PopUnder = true;
			Resizable = false;
			Scrollbars = false;
			Url = "about:blank";
			WindowHeight = 300;
			WindowWidth = 300;
		}

		public bool PopUnder
		{
			get {return (bool)ViewState["PopUnder"];}
			set {ViewState["PopUnder"] = value;}
		}

		public string Url
		{
			get {return (string)ViewState["Url"];}
			set {ViewState["Url"] = value;}
		}

		public int WindowHeight
		{
			get {return (int)ViewState["WindowHeight"];}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("WindowHeight must be greater than 0");
				}		
				ViewState["WindowHeight"] = value;
			}
		}
      
		public int WindowWidth
		{
			get {return (int)ViewState["WindowWidth"];}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("WindowWidth must be greater than 0");
				}		
				ViewState["WindowWidth"] = value;
			}
		}
    
		public bool Resizable
		{
			get {return (bool)ViewState["Resizable"];}
			set {ViewState["Resizable"] = value;}
		}

		public bool Scrollbars
		{
			get {return (bool)ViewState["Scrollbars"];}
			set {ViewState["Scrollbars"] = value;}
		}     
    		
		protected override void Render(HtmlTextWriter writer)
		{
			if (Page.Request == null || Page.Request.Browser.EcmaScriptVersion.Major >= 1)
			{
				StringBuilder javaScriptString = new StringBuilder();
				javaScriptString.Append("<script language='JavaScript'>");
				javaScriptString.Append("\n<!-- ");
				javaScriptString.Append("\nwindow.open('");
				javaScriptString.Append(Url + "', '" + ID);
				javaScriptString.Append("','toolbar=0,");
				javaScriptString.Append("height=" + (WindowHeight + ","));
				javaScriptString.Append("width=" + (WindowWidth + ","));
				javaScriptString.Append("resizable=" + Convert.ToInt16(Resizable).ToString() + ",");
				javaScriptString.Append("scrollbars=" + Convert.ToInt16(Scrollbars).ToString());
				javaScriptString.Append("');\n");
				if (PopUnder) javaScriptString.Append("window.focus();");
				javaScriptString.Append("\n-->\n");
				javaScriptString.Append("</script>\n");
				writer.Write(javaScriptString.ToString());
			}
			else
			{
				writer.Write( "<!-- This browser does not support JavaScript -->");
			}
		}

	}
}
