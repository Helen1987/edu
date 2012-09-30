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

public partial class MenuTemplates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	private string matchingDescription = "";

	protected string GetDescriptionFromTitle(string title)
	{
		// This assumes there's only one node with this tile.
		SiteMapNode node = SiteMap.RootNode;
		SearchNodes(node, title);
		return matchingDescription;
	}
	private void SearchNodes(SiteMapNode node, string title)
	{
		if (node.Title == title)
		{
			matchingDescription = node.Description;
			return;
		}
		else
		{
			foreach (SiteMapNode child in node.ChildNodes)
			{
				// Perform recursive search.
				SearchNodes(child, title);
			}
		}
	}
}
