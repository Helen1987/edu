using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using APress.WebParts.Samples;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            int i = 1;
            foreach (WebPart part in MyPartManager.WebParts)
            {
                if (part is GenericWebPart)
                {
                    part.Title = string.Format("Web Part Nr. {0}", i);
                    i++;
                }
            }
        }

        if (!this.IsPostBack)
        {
            MyCalendar.SelectedDate = DateTime.Now.AddDays(7);
        }

        if (!this.IsPostBack)
        {
            MenuItem Root = new MenuItem("Select Mode");

            foreach (WebPartDisplayMode mode in MyPartManager.DisplayModes)
            {
                if (mode.IsEnabled(MyPartManager))
                {
                    Root.ChildItems.Add(new MenuItem(mode.Name));
                }
            }

            PartsMenu.Items.Add(Root);
        }
    }
    protected void MyCalendar_SelectionChanged(object sender, EventArgs e)
    {

    }

    protected void PartsMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        foreach (WebPartDisplayMode mode in MyPartManager.DisplayModes)
        {
            if (mode.Name.Equals(e.Item.Text))
            {
                MyPartManager.DisplayMode = mode;
            }
        }
    }

    protected void MyCalendar_Load(object sender, EventArgs e)
    {
        GenericWebPart part = (GenericWebPart)MyCalendar.Parent;
        part.AllowClose = false;
        part.HelpMode = WebPartHelpMode.Modeless;
        part.HelpUrl = "CalendarHelp.htm"; 
    }

    protected void MyCustomers_Load(object sender, EventArgs e)
    {
        GenericWebPart part = (GenericWebPart)MyCustomers.Parent;
        part.Title = "Customers";
        part.TitleUrl = "http://www.apress.com";
        part.CatalogIconImageUrl = "CustomersSmall.jpg";
        part.Description = "Displays all customers in the database!";
    }

    protected void MyPartManager_AuthorizeWebPart(object sender, WebPartAuthorizationEventArgs e)
    {
        // Ignore authorization in Visual Studio Design Mode
        if (this.DesignMode)
            return;

        // Authorize a web part or not
        Type PartType = e.Type;
        if (PartType == typeof(CustomerNotesPart))
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!User.IsInRole("BUILTIN\\Administrators"))
                    e.IsAuthorized = true;
                else
                    e.IsAuthorized = false;
            }
            else
            {
                e.IsAuthorized = false;
            }
        }
    }
}