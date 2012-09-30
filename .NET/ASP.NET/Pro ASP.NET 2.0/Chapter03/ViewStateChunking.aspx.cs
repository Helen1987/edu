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

public partial class ViewStateChunking : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Random rnd = new Random();
		byte[] buffer = new byte[1050];
		rnd.NextBytes(buffer);
		ViewState["Data"] = buffer;
	}
}
