using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    MembershipUserCollection _MyUsers;

    public MembershipUser SelectedUser
    {
        get
        {
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        _MyUsers = Membership.GetAllUsers();
        UsersGridView.DataSource = _MyUsers;

        if (!this.IsPostBack)
        {
            UsersGridView.DataBind();
        }
    }

    protected void UsersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (UsersGridView.SelectedIndex >= 0)
        {
            MembershipUser Current = _MyUsers[(string)UsersGridView.SelectedValue];

            UsernameLabel.Text = Current.UserName;
            PwdQuestionLabel.Text = Current.PasswordQuestion;
            LastLoginLabel.Text = Current.LastLoginDate.ToShortDateString();
            EmailText.Text = Current.Email;
            CommentText.Text = Current.Comment;
            IsApprovedCheck.Checked = Current.IsApproved;
            IsLockedOutCheck.Checked = Current.IsLockedOut;
        }
    }

    protected void ActionUpdateUser_Click(object sender, EventArgs e)
    {
        if (UsersGridView.SelectedIndex >= 0)
        {
            MembershipUser Current = _MyUsers[(string)UsersGridView.SelectedValue];

            Current.Email = EmailText.Text;
            Current.Comment = CommentText.Text;
            Current.IsApproved = IsApprovedCheck.Checked;

            Membership.UpdateUser(Current);

            // Refresh the grids view
            UsersGridView.DataBind();
        } 
    }
}