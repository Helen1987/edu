using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder htmlString = new StringBuilder();

        // Has the request been authenticated?
        if (Request.IsAuthenticated)
        {
            // Display generic identity information.
            // This is always available, regardless of the type of
            // authentication.
            htmlString.Append("<h3>Generic User Information</h3>");
            htmlString.Append("<b>Name: </b>");
            htmlString.Append(User.Identity.Name);
            htmlString.Append("<br><b>Authenticated With: </b>");
            htmlString.Append(User.Identity.AuthenticationType);
            htmlString.Append("<br><br>");

            // Was forms authentication used?
            if (User.Identity is FormsIdentity)
            {
                // Get the ticket.
                FormsAuthenticationTicket ticket =
                 ((FormsIdentity)User.Identity).Ticket;

                htmlString.Append("<h3>Ticket User Information</h3>");
                htmlString.Append("<b>Name: </b>");
                htmlString.Append(ticket.Name);
                htmlString.Append("<br><b>Issued at: </b>");
                htmlString.Append(ticket.IssueDate);
                htmlString.Append("<br><b>Expires at: </b>");
                htmlString.Append(ticket.Expiration);
                htmlString.Append("<br><b>Cookie version: </b>");
                htmlString.Append(ticket.Version);
            }
            // Display the information.
            LegendInfo.Text = htmlString.ToString();
        }
    }

    protected void SignOutAction_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
    }
}