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

public partial class StyleAttributes : System.Web.UI.Page
{
	protected void Page_Load(object sender, System.EventArgs e)
	{
		// Only perform the initialization the first time the page is requested.
		// After that, this information is tracked in view state.
		if (!Page.IsPostBack)
		{
			// Set the style attributes to configure appearance.
			TextBox1.Style["font-size"] = "20px";
			TextBox1.Style["color"] = "red";

			// Use a slightly different but equivalent syntax
			// for setting a style attribute.
			TextBox1.Style.Add("background-color", "lightyellow");

			// Set the default text.
			TextBox1.Value = "<Enter e-mail address here>";

			// Set other nonstandard attributes.
			TextBox1.Attributes["onfocus"] = "alert(TextBox1.value)";
		}
	}

}
