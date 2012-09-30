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

public partial class ViewStateObjects : System.Web.UI.Page
{

	// This will be created at the beginning of each request.
	Hashtable textToSave = new Hashtable();


	protected void cmdSave_Click(object sender, EventArgs e)
	{
		// Put the text in the Hashtable.
		SaveAllText(Page.Controls, true);

		// Store the entire collection in view state.
		ViewState["TextData"] = textToSave;
	}

	private void SaveAllText(ControlCollection controls, bool saveNested)
	{
		foreach (Control control in controls)
		{
			if (control is TextBox)
			{
				// Add the text to a collection.
				textToSave.Add(control.ID, ((TextBox)control).Text);
			}
			if ((control.Controls != null) && saveNested)
			{
				SaveAllText(control.Controls, true);
			}
		}
	}

	protected void cmdRestore_Click(object sender, EventArgs e)
	{
		if (ViewState["TextData"] != null)
		{
			// Retrieve the hashtable.
			Hashtable savedText = (Hashtable)ViewState["TextData"];

			// Display all the text by looping through the hashtable.
			lblResults.Text = "";
			foreach (DictionaryEntry item in savedText)
			{
				lblResults.Text += (string)item.Key + " = " + (string)item.Value + "<br>";
			}
		}
	}
}
