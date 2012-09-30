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

public partial class CustomizableMasterPage_master : System.Web.UI.MasterPage
{
    // Page events are wired up automatically to methods 
    // with the following names:
    // Page_Load, Page_AbortTransaction, Page_CommitTransaction,
    // Page_DataBinding, Page_Disposed, Page_Error, Page_Init, 
    // Page_Init Complete, Page_Load, Page_LoadComplete, Page_PreInit
    // Page_PreLoad, Page_PreRender, Page_PreRenderComplete, 
    // Page_SaveStateComplete, Page_Unload
    protected void Page_Load(object sender, EventArgs e)
    {
		// A dead end.
		if (!Page.IsPostBack)
		{
			if (Page.PreviousPage != null)
			{
				CustomizableMasterPage_master previous =
					Page.PreviousPage.Master  as CustomizableMasterPage_master;
				if (previous != null)
				{
					BannerText = previous.BannerText;
				}
			}
		}
    }

	public string BannerText
	{
		get
		{
			return lblTitleContent.Text;
		}
		set
		{
			lblTitleContent.Text = value;
		}
	}

}
