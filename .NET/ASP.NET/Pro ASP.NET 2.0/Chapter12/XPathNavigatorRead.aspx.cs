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
using System.Xml;
using System.Xml.XPath;
using System.Text;

public partial class XPathNavigatorRead : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string xmlFile = Server.MapPath("DvdList.xml");

		// Load the XML file in an XmlDocument.
		XmlDocument doc = new XmlDocument();
		doc.Load(xmlFile);

		// Create the navigator.
		XPathNavigator xnav = doc.CreateNavigator();

		XmlText.Text = GetXNavDescr(xnav, 0);
    }

	private string GetXNavDescr(XPathNavigator xnav, int level)
	{
		string indent = "";
		for (int i = 0; i < level; i++)
			indent += "&nbsp; &nbsp; &nbsp;";

		StringBuilder str = new StringBuilder("");

		switch (xnav.NodeType)
		{
			case XPathNodeType.Root:
				str.Append("<b>ROOT</b>");
				str.Append("<br>");
				break;

			case XPathNodeType.Element:
				str.Append(indent);
				str.Append("Element: <b>");
				str.Append(xnav.Name);
				str.Append("</b><br>");
				break;

			case XPathNodeType.Text:
				str.Append(indent);
				str.Append(" - Value: <b>");
				str.Append(xnav.Value);
				str.Append("</b><br>");
				break;

			case XPathNodeType.Comment:
				str.Append(indent);
				str.Append("Comment: <b>");
				str.Append(xnav.Value);
				str.Append("</b><br>");
				break;
		}

		if (xnav.HasAttributes)
		{
			xnav.MoveToFirstAttribute();
			do
			{
				str.Append(indent);
				str.Append(" - Attribute: <b>");
				str.Append(xnav.Name);
				str.Append("</b> Value: <b>");
				str.Append(xnav.Value);
				str.Append("</b><br>");
			} while (xnav.MoveToNextAttribute());

			// Return to the parent.
			xnav.MoveToParent();
		}

		if (xnav.HasChildren)
		{
			xnav.MoveToFirstChild();

			do
			{
				str.Append(GetXNavDescr(xnav, level + 1));
			} while (xnav.MoveToNext());

			// Return to the parent.
			xnav.MoveToParent();
		}

		return str.ToString();
	}
}
