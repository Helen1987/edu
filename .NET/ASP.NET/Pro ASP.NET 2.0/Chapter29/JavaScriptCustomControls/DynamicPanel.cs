using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

/// <summary>
/// Summary description for DynamicPanel
/// </summary>
namespace DynamicControls
{

	public class DynamicPanel : Panel, ICallbackEventHandler, ICallbackContainer
	{


		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			string script = @"<script language='JavaScript'>
       function RefreshPanel(result, context)
       {
         if (result != '')
         {
           var separator = result.indexOf('_'); 
           var elementName = result.substr(0, separator);
           var panel = document.getElementById(elementName);
           panel.innerHTML = result.substr(separator+1);
         }
       }
    </script>";

			Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
				"RefreshPanel", script);

		}

		public event EventHandler Refreshing;

		public void RaiseCallbackEvent(string eventArgument)
		{
			// Fire an event to notify the client a refresh has been requested.
	      	if (Refreshing != null)
			{
				Refreshing(this, EventArgs.Empty);
			}					
		}       
               
        public string GetCallbackResult()
        {
            EnsureChildControls();

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter writer = new HtmlTextWriter(sw))
                {
                    writer.Write(this.ClientID + "_");
                    this.RenderContents(writer);
                }
                return sw.ToString();
            }
        }

        public string GetCallbackScript(IButtonControl buttonControl, string argument)
        {
            return Page.ClientScript.GetCallbackEventReference(
  this, "", "RefreshPanel", "null");
        }
    }

	
}