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
using System.Messaging;

public partial class CustomDependencyTest : System.Web.UI.Page
{
	protected void Page_PreRender(object sender, EventArgs e)
	{
		lblInfo.Text += "<br>";
	}

	private string queueName = @".\Private$\TestQueue";
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!this.IsPostBack)
		{
			// Set up the queue.
			MessageQueue queue;
			if (MessageQueue.Exists(queueName))
			{
				queue = new MessageQueue(queueName);
			}
			else
			{
				queue = MessageQueue.Create(@".\Private$\TestQueue");
			}

			lblInfo.Text += "Creating dependent item...<br/>";
			Cache.Remove("Item");
			MessageQueueCacheDependency dependency = new
			 MessageQueueCacheDependency(queueName);
			string item = "Dependent cached item";
			lblInfo.Text += "Adding dependent item<br/>";
			Cache.Insert("Item", item, dependency);
		}
	}

	protected void cmdModfiy_Click(object sender, EventArgs e)
	{
		MessageQueue queue = new MessageQueue(queueName);
		
		// (You could send a custom object instead
		//  of a string.)
		queue.Send("Invalidate!");
		lblInfo.Text += "Message sent<br/>";
	}

	protected void cmdGetItem_Click(object sender, EventArgs e)
	{
		if (Cache["Item"] == null)
		{
			lblInfo.Text += "Cache item no longer exits.<br>";
		}
		else
		{
			string cacheInfo = (string)Cache["Item"];
			lblInfo.Text += "Retrieved item with text: '" + cacheInfo + "'<br>";
		}
	}
}
