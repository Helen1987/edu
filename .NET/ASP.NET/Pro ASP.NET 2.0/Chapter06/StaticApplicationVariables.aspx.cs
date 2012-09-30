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
using System.Text;
using ASP;

public partial class StaticApplicationVariables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		StringBuilder builder = new StringBuilder();
		foreach (string file in Global.FileList)
		{
			builder.Append(file + "<br />");
		}
		lblInfo.Text = builder.ToString();
    }
}
