using System;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Resources;
using System.Globalization;

public partial class Default_aspx : System.Web.UI.Page
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
    // These are simple string resources
    LegendFirstname.Text = Resources.MyResourceStrings.LegendFirstname;
    LegendLastname.Text = Resources.MyResourceStrings.LegendLastname;
    LegendAge.Text = Resources.MyResourceStrings.LegendAge;

    // This is the XML document added to the resources as file
    DocumentXml.DocumentContent = Resources.MyResourceStrings.MyDocument;
  }

  protected void GenerateAction_Click(object sender, EventArgs e)
  {
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(Resources.MyResourceStrings.MyDocument);

    XmlNode TextNode;
    XmlNamespaceManager NsMgr = new XmlNamespaceManager(doc.NameTable);
    NsMgr.AddNamespace("ns1", "uri:AspNetPro20/Chapter16/Demo1");
    NsMgr.AddNamespace("w", "http://schemas.microsoft.com/office/word/2003/wordml");

    TextNode = doc.SelectSingleNode("//ns1:Firstname//w:p", NsMgr);
    TextNode.InnerXml = string.Format("<w:r><w:t>{0}</w:t></w:r>", TextFirstname.Text);

    TextNode = doc.SelectSingleNode("//ns1:Lastname//w:p", NsMgr);
    TextNode.InnerXml = string.Format("<w:r><w:t>{0}</w:t></w:r>", TextLastname.Text);

    TextNode = doc.SelectSingleNode("//ns1:Age//w:p", NsMgr);
    TextNode.InnerXml = string.Format("<w:r><w:t>{0}</w:t></w:r>", TextAge.Text);

    // Clear the response
    Response.Clear();
    Response.ContentType = "application/msword";
    Response.Write(doc.OuterXml);
    Response.End();
  }
}