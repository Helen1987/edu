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

public partial class RepeatedValueBinding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			// create the data source
			Hashtable ht = new Hashtable(3);
			ht.Add("Lasagna", "Key1");
			ht.Add("Spaghetti", "Key2");
			ht.Add("Pizza", "Key3");

			// set the controls' DataSource property
			Select1.DataSource = ht;
			Select2.DataSource = ht;
			Listbox1.DataSource = ht;
			DropdownList1.DataSource = ht;
			CheckList1.DataSource = ht;
			OptionList1.DataSource = ht;

			// bind the data to all the control
			Page.DataBind();
		}
    }
	protected void cmdGetSelection_Click(object sender, EventArgs e)
	{
		if (Select1.SelectedIndex != -1)
			Result.Text += "- Item selected in Select1: " + Select1.Items[Select1.SelectedIndex].Text + " - " + Select1.Value + "<br>";
		
		if (Select2.SelectedIndex != -1)
			Result.Text += "- Item selected in Select2: " + Select2.Items[Select2.SelectedIndex].Text + " - " + Select2.Value + "<br>";

		if (Listbox1.SelectedIndex != -1)
			Result.Text += "- Item selected in Listbox1: " + Listbox1.SelectedItem.Text + " - " + Listbox1.SelectedItem.Value + "<br>";

		if (DropdownList1.SelectedIndex != -1)
			Result.Text += "- Item selected in DropdownList1: " + DropdownList1.SelectedItem.Text + " - " + DropdownList1.SelectedItem.Value + "<br>";

		if (OptionList1.SelectedIndex != -1)
			Result.Text += "- Item selected in OptionList1: " + OptionList1.SelectedItem.Text + " - " + OptionList1.SelectedItem.Value + "<br>";

		if (CheckList1.SelectedIndex != -1)
		{
			Result.Text += "- Items selected in CheckList1: ";
			foreach (ListItem li in CheckList1.Items)
			{
				if (li.Selected)
					Result.Text += li.Text + " - " + li.Value + " ";
			}
		}
	}
}
