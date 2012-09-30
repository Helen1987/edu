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
using System.Text;

public partial class XmlDOM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string xmlFile = Server.MapPath("DvdList.xml");

		// Load the XML file in an XmlDocument.
		XmlDocument doc = new XmlDocument();
		doc.Load(xmlFile);

		// Write the description text.
		XmlText.Text = GetChildNodesDescr(doc.ChildNodes, 0);
    }


	private string GetChildNodesDescr(XmlNodeList nodeList, int level)
	{
		string indent = "";
		for (int i = 0; i < level; i++)
			indent += "&nbsp; &nbsp; &nbsp;";

		StringBuilder str = new StringBuilder("");

		foreach (XmlNode node in nodeList)
		{
			switch (node.NodeType)
			{
				case XmlNodeType.XmlDeclaration:
					str.Append("XML Declaration: <b>");
					str.Append(node.Name);
					str.Append(" ");
					str.Append(node.Value);
					str.Append("</b><br>");
					break;

				case XmlNodeType.Element:
					str.Append(indent);
					str.Append("Element: <b>");
					str.Append(node.Name);
					str.Append("</b><br>");
					break;

				case XmlNodeType.Text:
					str.Append(indent);
					str.Append(" - Value: <b>");
					str.Append(node.Value);
					str.Append("</b><br>");
					break;

				case XmlNodeType.Comment:
					str.Append(indent);
					str.Append("Comment: <b>");
					str.Append(node.Value);
					str.Append("</b><br>");
					break;
			}

			if (node.Attributes != null)
			{
				foreach (XmlAttribute attrib in node.Attributes)
				{
					str.Append(indent);
					str.Append(" - Attribute: <b>");
					str.Append(attrib.Name);
					str.Append("</b> Value: <b>");
					str.Append(attrib.Value);
					str.Append("</b><br>");
				}
			}

			if (node.HasChildNodes)
				str.Append(GetChildNodesDescr(node.ChildNodes, level + 1));
		}

		return str.ToString();
	} 
}
