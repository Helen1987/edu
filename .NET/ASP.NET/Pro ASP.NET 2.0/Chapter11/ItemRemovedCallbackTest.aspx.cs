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

public partial class ItemRemovedCallbackTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!this.IsPostBack)
		{
			lblInfo.Text += "Creating items...<br>";
			string itemA = "item A";
			string itemB = "item B";
			Cache.Insert("itemA", itemA, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.Default, new CacheItemRemovedCallback(ItemRemovedCallback));
			Cache.Insert("itemB", itemB, null, DateTime.Now.AddMinutes(60), TimeSpan.Zero, CacheItemPriority.Default, new CacheItemRemovedCallback(ItemRemovedCallback));
		}
    }
	protected void cmdCheck_Click(object sender, EventArgs e)
	{
		string itemList = "";
		foreach (DictionaryEntry item in Cache)
		{
			itemList += item.Key.ToString() + " ";
		}
		lblInfo.Text += "<br>Found: " + itemList + "<br>";
	}
	protected void cmdRemove_Click(object sender, EventArgs e)
	{
		lblInfo.Text += "<br>Removing itemA.<br>";
		Cache.Remove("itemA");
	}

	private void ItemRemovedCallback(string key, object value,
			CacheItemRemovedReason reason)
	{
		// This fires after the request has ended, when the
		// item is removed.

		// If either item has been removed, make sure
		// the other item is also removed.
		if (key == "itemA" || key == "itemB")
		{
			Cache.Remove("itemA");
			Cache.Remove("itemB");
		}
	}
}
