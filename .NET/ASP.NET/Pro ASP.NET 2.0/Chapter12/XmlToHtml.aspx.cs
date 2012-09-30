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
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;

public partial class XmlToHtml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string xslFile = Server.MapPath("DvdList.xsl");
		string xmlFile = Server.MapPath("DvdList.xml");
		string htmlFile = Server.MapPath("DvdList.htm");

		XslTransform transf = new XslTransform();
		transf.Load(xslFile);
		transf.Transform(xmlFile, htmlFile);

		// Create an XPathDocument.
		XPathDocument xdoc = new XPathDocument(new XmlTextReader(xmlFile));

		// Create an XPathNavigator.

		XPathNavigator xnav = xdoc.CreateNavigator();

		// Transform the XML
		XmlReader reader = transf.Transform(xnav, null);

		// Go the the content and write it.
		reader.MoveToContent();
		Response.Write(reader.ReadOuterXml());
		reader.Close();
    }
}
