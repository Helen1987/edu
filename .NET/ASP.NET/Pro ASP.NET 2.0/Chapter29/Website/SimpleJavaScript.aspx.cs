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

public partial class SimpleJavaScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		TextBox1.Attributes.Add("onMouseOver",
				"alert('Your mouse is hovering on TextBox1.');");
		TextBox2.Attributes.Add("onMouseOver",
			"alert('Your mouse is hovering on TextBox2.');");
    }
}
