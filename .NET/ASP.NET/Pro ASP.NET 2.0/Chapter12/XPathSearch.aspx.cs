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

public partial class XPathSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		// Load the XML file.
		string xmlFile = Server.MapPath("DvdList.xml");
		XmlDocument doc = new XmlDocument();
		doc.Load(xmlFile);

		// Retrieve the title of every science fiction move.
		XmlNodeList nodes = doc.SelectNodes("/DvdList/DVD/Title[../@Category='Science Fiction']");

		// Display the titles.
		StringBuilder str = new StringBuilder();
		foreach (XmlNode node in nodes)
		{
			str.Append("Found: <b>");

			// Show the text contained in this <Title> element.
			str.Append(node.ChildNodes[0].Value);
			str.Append("</b><br>");
		}
		XmlText.Text = str.ToString();
    }
}
