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

public partial class UseCustomSettings_aspx : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		StringBuilder builder = new StringBuilder();
		Configuration config =
			System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(
			   Request.ApplicationPath  );

		OrderService custSection = (OrderService)config.GetSection("orderService");

		lblInfo.Text += "Retrieved service information...<br />" +
		  "<b>Location:</b> " + custSection.Location +
		  "<br /><b>Available:</b> " + custSection.Available.ToString() +
		  "<br /><b>Timeout:</b> " + custSection.PollTimeout.ToString() + "<br /><br />";

	}
}
