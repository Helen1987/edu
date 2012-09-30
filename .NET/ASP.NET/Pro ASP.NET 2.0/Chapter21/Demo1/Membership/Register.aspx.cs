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
using System.Diagnostics;

public partial class Register : System.Web.UI.Page
{
    private short _Age;
    private string _Firstname, _Lastname;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            _Age = -1;
            _Firstname = _Lastname = string.Empty;
        }
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        // Find the correct wizard step
        WizardStepBase step = null;
        for (int i = 0; i < RegisterUser.WizardSteps.Count; i++)
        {
            if (RegisterUser.WizardSteps[i].ID == "NameStep")
            {
                step = RegisterUser.WizardSteps[i];
                break;
            }
        }

        if (step != null)
        {
            _Firstname = ((TextBox)step.FindControl("FirstnameText")).Text;
            _Lastname = ((TextBox)step.FindControl("LastnameText")).Text;
            _Age = short.Parse(((TextBox)step.FindControl("AgeTExt")).Text);

            // Store the information
            Debug.WriteLine(string.Format("{0} {1} {2}", _Firstname, _Lastname, _Age));
        }    
    }
}
