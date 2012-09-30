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
using System.Web.Caching;
using System.IO;

public partial class AggregateDependency : System.Web.UI.Page
{
	protected void Page_PreRender(object sender, EventArgs e)
	{
		lblInfo.Text += "<br>";
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			lblInfo.Text += "Creating dependent item...<br>";
			Cache.Remove("Dependent");
			System.Web.Caching.CacheDependency dep1 =
			 new System.Web.Caching.CacheDependency(Server.MapPath("dependency.txt"));
			System.Web.Caching.CacheDependency dep2 =
			 new System.Web.Caching.CacheDependency(Server.MapPath("dependency2.txt"));


			// Create the aggregate.
			CacheDependency[] dependencies = new CacheDependency[] { dep1, dep2 };
			AggregateCacheDependency aggregateDep = new AggregateCacheDependency();
			aggregateDep.Add(dependencies);

			string item = "Dependent cached item";
			lblInfo.Text += "Adding dependent item<br>";
			Cache.Insert("Dependent", item, aggregateDep);
		}
	}
	protected void cmdModfiy_Click(object sender, EventArgs e)
	{
		lblInfo.Text += "Modifying dependency2.txt file.<br>";
		StreamWriter w = File.CreateText(Server.MapPath("dependency2.txt"));
		w.Write(DateTime.Now);
		w.Flush();
		w.Close();
	}
	protected void cmdGetItem_Click(object sender, EventArgs e)
	{
		if (Cache["Dependent"] == null)
		{
			lblInfo.Text += "Cache item no longer exits.<br>";
		}
		else
		{
			string cacheInfo = (string)Cache["Dependent"];
			lblInfo.Text += "Retrieved item with text: '" + cacheInfo + "'<br>";
		}
	}
}
