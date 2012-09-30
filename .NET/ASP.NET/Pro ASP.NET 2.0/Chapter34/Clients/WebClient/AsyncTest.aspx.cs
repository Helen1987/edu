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
using localhost;
using System.Threading;

public partial class AsyncTest : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{

	}
	protected void cmdSynchronous_Click(object sender, EventArgs e)
	{
		// Record the start time.
		DateTime startTime = DateTime.Now;

		// Get the web service data.
		EmployeesService proxy = new EmployeesService();
		try
		{
			GridView1.DataSource = proxy.GetEmployeesSlow();
		}
		catch (Exception err)
		{
			lblInfo.Text = "Problem contacting web service.";
			return;
		}

		GridView1.DataBind();

		// Perform some other time-consuming tasks.
		DoSomethingSlow();

		// Determine the total time taken.
		TimeSpan timeTaken = DateTime.Now.Subtract(startTime);
		lblInfo.Text = "Synchronous operations took " + timeTaken.TotalSeconds +
		  " seconds.";

	}

	private void DoSomethingSlow()
	{
		System.Threading.Thread.Sleep(3000);
	}

	protected void cmdAsynchronous_Click(object sender, EventArgs e)
	{
		// Record the start time.
		DateTime startTime = DateTime.Now;

		// Start the web service on another thread.
		EmployeesService proxy = new EmployeesService();
		GetEmployeesDelegate async = new GetEmployeesDelegate(proxy.GetEmployeesSlow);
		IAsyncResult handle = async.BeginInvoke(null, null);

		// Perform some other time-consuming tasks.
		DoSomethingSlow();

		// Retrieve the result. If it isn't ready, wait.
		try
		{
			GridView1.DataSource = async.EndInvoke(handle);
		}
		catch (Exception err)
		{
			lblInfo.Text = "Problem contacting web service.";
			return;
		}
		GridView1.DataBind();

		// Determine the total time taken.
		TimeSpan timeTaken = DateTime.Now.Subtract(startTime);
		lblInfo.Text = "Asynchronous operations took " + timeTaken.TotalSeconds +
		  " seconds.";

	}
	public delegate DataSet GetEmployeesDelegate();

	protected void cmdMultiple_Click(object sender, EventArgs e)
	{
		// Record the start time.
		DateTime startTime = DateTime.Now;

		EmployeesService proxy = new EmployeesService();
		GetEmployeesDelegate async = new GetEmployeesDelegate(proxy.GetEmployeesSlow);

		// Call three methods asynchronously.
		IAsyncResult handle1 = async.BeginInvoke(null, null);
		IAsyncResult handle2 = async.BeginInvoke(null, null);
		IAsyncResult handle3 = async.BeginInvoke(null, null);

		// Create an array of WaitHandle objects.
		WaitHandle[] waitHandles = {handle1.AsyncWaitHandle,
     handle2.AsyncWaitHandle, handle3.AsyncWaitHandle};

		// Wait for all the calls to finish.
		WaitHandle.WaitAll(waitHandles);

		// You can now retrieve the results.
		DataSet ds1 = async.EndInvoke(handle1);
		DataSet ds2 = async.EndInvoke(handle2);
		DataSet ds3 = async.EndInvoke(handle3);

		// Merge all the results into one table and display it.
		DataSet dsMerge = new DataSet();
		dsMerge.Merge(ds1);
		dsMerge.Merge(ds2);
		dsMerge.Merge(ds3);
		GridView1.DataSource = dsMerge;
		GridView1.DataBind();

		// Determine the total time taken.
		TimeSpan timeTaken = DateTime.Now.Subtract(startTime);
		lblInfo.Text = "Calling three methods took " + timeTaken.TotalSeconds +
		  " seconds.";

	}
}
