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

public partial class TimeDisplay : System.Web.UI.UserControl
{
	protected void Page_Load(object sender, EventArgs e)
	{
		RefreshTime();
	}

	protected void lnkTime_Click(object sender, EventArgs e)
	{
		RefreshTime();
	}

	public void RefreshTime()
	{
		if (format == "")
		{
			lnkTime.Text = DateTime.Now.ToLongTimeString();
		}
		else
		{
			// This will throw an exception for invalid format strings,
			// which is acceptable.
			lnkTime.Text = DateTime.Now.ToString(format);
		}

	}

	private string format;
	public string Format
	{
		get { return format; }
		set { format = value; }
	}


}
