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

public partial class DynamicButton : System.Web.UI.Page
{
    private void Page_Load(object sender, EventArgs e)
    {
		// Create a new button object.
		Button newButton = new Button();

		// Assign some text and an ID so you can retrieve it later.
		newButton.Text = "* Dynamic Button *";
		newButton.ID = "newButton";

		// Attach an event handler to the Button.Click event.
		newButton.Click += new System.EventHandler(this.Button_Click);

		// Add the putton to a placeholder.
		PlaceHolder1.Controls.Add(newButton);
    }

	protected void Button_Click(object sender, System.EventArgs e)
	{
		Label1.Text = "You clicked the dynamic button.";
	}

	protected void cmdReset_Click(object sender, System.EventArgs e)
	{
		Label1.Text = "(No value.)";
	}

	protected void cmdRemove_Click(object sender, System.EventArgs e)
	{
		// Search for the button, no matter what level it's at.
		Button foundButton = (Button)Page.FindControl("newButton");

		// Remove the button.
		if (foundButton != null)
		{
			foundButton.Parent.Controls.Remove(foundButton);
		}
	}

	protected void cmdCreate_Click(object sender, System.EventArgs e)
	{
		// (Button is automatically created in postback.)
	}
}
