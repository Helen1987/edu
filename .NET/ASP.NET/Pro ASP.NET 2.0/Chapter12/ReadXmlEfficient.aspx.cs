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
using System.Text;
using System.Xml;

public partial class ReadXmlEfficient : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		ReadXML();
	}

	private void ReadXML()
	{
		string xmlFile = Server.MapPath("DvdList.xml");

		// Create the reader.
		XmlTextReader reader = new XmlTextReader(xmlFile);

		StringBuilder str = new StringBuilder();
		reader.ReadStartElement("DvdList");

		// Read all the <DVD> elements.
		while (reader.Read())
		{
			if ((reader.Name == "DVD") && (reader.NodeType == XmlNodeType.Element))
			{
				reader.ReadStartElement("DVD");
				str.Append("<ul><b>");
				str.Append(reader.ReadElementString("Title"));
				str.Append("</b><li>");
				str.Append(reader.ReadElementString("Director"));
				str.Append("</li><li>");
				str.Append(String.Format("{0:C}",
					Decimal.Parse(reader.ReadElementString("Price"))));
				str.Append("</li></ul>");
			}
		}
		// Close the reader and show the text.
		reader.Close();
		XmlText.Text = str.ToString();
	}

}
