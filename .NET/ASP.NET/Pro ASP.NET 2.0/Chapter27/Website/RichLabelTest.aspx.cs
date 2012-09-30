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
using System.IO;

public partial class XmlLabelTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		StreamReader r = File.OpenText(Server.MapPath("DvdList.xml"));
		string text = r.ReadToEnd();
		r.Close();

		RichLabel1.Text = text;
	}
}
