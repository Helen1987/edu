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

public partial class SingleValueBinding : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		this.DataBind();
    }
	protected string GetFilePath()
	{
		return "apress.gif";
	}

	protected string FilePath
	{
		get { return "apress.gif"; }
	}
}
