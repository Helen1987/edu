using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class RolesTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    private void WriteResults(string[] Results) 
    {
        StringBuilder Info = new StringBuilder();
        foreach (string Result in Results)
        {
            Info.AppendFormat("{0}<br>", Result);
        }
        ResultsLabel.Text = Info.ToString();
    }

    protected void DeleteRole_Click(object sender, EventArgs e)
    {
        if (Roles.DeleteRole(RoleNameText.Text))
            ResultsLabel.Text = "Role deleted successfully!";
        else
            ResultsLabel.Text = "Unable to delete roles!";
    }
    
    protected void FindUsersInRole_Click(object sender, EventArgs e)
    {
        ResultsLabel.Text = "";
        WriteResults(Roles.FindUsersInRole(RoleNameText.Text, UserNameText.Text));
    }
    
    protected void GetAll_Click(object sender, EventArgs e)
    {
        WriteResults(Roles.GetAllRoles());
    }
    
    protected void GetRolesForUser_Click(object sender, EventArgs e)
    {
        WriteResults(Roles.GetRolesForUser(UserNameText.Text));
    }
    
    protected void GetUsersInRole_Click(object sender, EventArgs e)
    {
        WriteResults(Roles.GetUsersInRole(RoleNameText.Text));
    }
    
    protected void IsUserInRole_Click(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(UserNameText.Text, RoleNameText.Text))
            ResultsLabel.Text = "Yes";
        else
            ResultsLabel.Text = "No";
    }
    
    protected void AddUserToRole_Click(object sender, EventArgs e)
    {
        Roles.AddUserToRole(UserNameText.Text, RoleNameText.Text);
    }

    protected void RemoveUserFromRole_Click(object sender, EventArgs e)
    {
        Roles.RemoveUserFromRole(UserNameText.Text, RoleNameText.Text);
    }
}
