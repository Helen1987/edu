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

public partial class IncrementalDownloadGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			// Get data.
			DataSet ds = new DataSet();
			ds.ReadXml(Server.MapPath("Books.xml"));
			DataGrid1.DataSource = ds.Tables["Book"];
			DataGrid1.DataBind();
		}
    }
}
