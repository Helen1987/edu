using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.Threading;
using System.Messaging;

public class TimerTestCacheDependency : CacheDependency
{
	private Timer timer;
	private int pollTime = 5000;
	private int count = 0;

	public TimerTestCacheDependency()
	{
		// Check immediately and then wait the poll time
		// for each subsequent check (same as CacheDependency behavior).
		timer = new Timer(new TimerCallback(CheckDependencyCallback),
		  this, 0, pollTime);
	}

	private void CheckDependencyCallback(object sender)
	{
		// Check your resource here (the polling).
		// If it's changed, notify ASP.NET:
		count++;
		if (count > 4)
		{
			base.NotifyDependencyChanged(this, EventArgs.Empty);
			timer.Dispose();
		}
	}

	protected override void DependencyDispose()
	{
		// Clean up code goes here.
		// This is called after the dependency signals a change
		// (and therefore isn't needed anymore).
		if (timer != null) timer.Dispose();
	}
}

public class MessageQueueCacheDependency : CacheDependency
{
	// The queue to monitor.
	private MessageQueue queue;
	
	public MessageQueueCacheDependency(string queueName)
	{
		queue = new MessageQueue(queueName);

		// Wait for the queue message on another thread.
		WaitCallback callback = new WaitCallback(WaitForMessage);
		ThreadPool.QueueUserWorkItem(callback);
	}
	
	private void WaitForMessage(object state)
	{
		// Check your resource here (the polling).
		// This blocks until a message is sent to the queue.
		Message msg = queue.Receive();
		// (If you're looking for something specific, you could
		//  perform a loop and check the Message object here
		//  before invalidating the cached item.)
		base.NotifyDependencyChanged(this, EventArgs.Empty);
	}

}

