using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DynamicPanelRefreshLink
/// </summary>
namespace DynamicControls
{

	public class DynamicPanelRefreshLink : LinkButton
	{
		public DynamicPanelRefreshLink()
		{
			PanelID = "";
		}

		public string PanelID
		{
			get	{ return (string)ViewState["DynamicPanelID"]; }
			set	{ ViewState["DynamicPanelID"] = value; }
		}
		
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			if (!DesignMode)
			{
				DynamicPanel pnl = (DynamicPanel)Page.FindControl(PanelID);
				if (pnl != null)
				{
					writer.AddAttribute("onclick", pnl.GetCallbackScript(this, ""));
					writer.AddAttribute("href", "#");
				}
			}
		}

		
		
	}
}