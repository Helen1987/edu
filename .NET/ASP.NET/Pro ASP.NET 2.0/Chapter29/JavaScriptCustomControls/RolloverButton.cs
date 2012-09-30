using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CustomServerControlsLibrary
{
	public class RollOverButton : WebControl, IPostBackEventHandler
	{
		public RollOverButton() : base(HtmlTextWriterTag.Img)
		{
			ImageUrl = "";
			MouseOverImageUrl = "";
		}

		public string ImageUrl
		{
			get {return (string)ViewState["ImageUrl"];}
			set {ViewState["ImageUrl"] = value;}
		}

		public string MouseOverImageUrl
		{
			get {return (string)ViewState["MouseOverImageUrl"];}
			set {ViewState["MouseOverImageUrl"] = value;}
		}

		protected override void AddAttributesToRender(HtmlTextWriter output)
		{
			output.AddAttribute("name", ClientID);
			output.AddAttribute("src", ImageUrl);
			output.AddAttribute("onClick", Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this)));
			
			output.AddAttribute("onMouseOver",
				"swapImg('" + this.ClientID + "', '" +
				MouseOverImageUrl + "');");

			output.AddAttribute("onMouseOut",
				"swapImg('" + this.ClientID + "', '" +
				ImageUrl + "');");
		}

		protected override void OnPreRender(EventArgs e)
		{

			if (!Page.ClientScript.IsClientScriptBlockRegistered("swapImg"))
			{
				string script = 
					"<script language='JavaScript'> " + 
					"function swapImg(id, url) { " + 
					"elm = document.getElementById(id); " +
					"if(elm) elm.src=url; }" +
					"</script> ";

				Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
		  "swapImg", script);

			}        
      
			base.OnPreRender (e);
		}

		public event EventHandler ImageClicked;

		public void RaisePostBackEvent(string eventArgument)
		{
			OnImageClicked(new EventArgs());
		}

		protected virtual void OnImageClicked(EventArgs e)
		{
			// Check for at least one listener and then raise the event.
			if (ImageClicked != null)
				ImageClicked(this, e);
		}

	}
}
