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
    protected void Page_Load(object sender, EventArgs e)
    {
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
}