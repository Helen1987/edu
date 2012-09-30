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

public partial class SimpleViewState : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Label1.Text = "Hello World!";
    }
	protected void Button1_Click(object sender, EventArgs e)
	{
		string viewStateString = "/wEPDwUKLTE2MjY5MTY1NQ9kFgICAw9kFgICAQ8PFgIeBFRleHQFDEhlbGxvIFdvcmxkIWRkZPsbiNOyNAufEt7OvNIbVYcGWHqf";
		// viewStateString contains the view state information.
		// Convert the Base64 string to an ordinary array of bytes
		// representing ASCII characters.
		byte[] stringBytes = Convert.FromBase64String(viewStateString);

		// Deserialize and display the string.
		string decodedViewState = System.Text.Encoding.ASCII.GetString(stringBytes);
		Label1.Text = decodedViewState;
	}
}
