using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsClient.localhost;

namespace WindowsClient
{
	public partial class AsyncTest : Form
	{
		public AsyncTest()
		{
			InitializeComponent();
		}

		private EmployeesService proxy = new EmployeesService();
		private Guid requestID;


		private void cmdGetEmployees_Click(object sender, EventArgs e)
		{
			// Disable the button so that only one asynchronous
			// call will be permitted at a time.
			cmdGetEmployees.Enabled = false;
			cmdCancel.Enabled = true;
					
			// Call the web service asynchronously.
			requestID = Guid.NewGuid();
			proxy.GetEmployeesSlowAsync(requestID);
		}

        private void GetEmployeesCompleted(object sender, GetEmployeesSlowCompletedEventArgs e)
		{
			if (!e.Cancelled)
			{
				// Get the result.
				try
				{
					dataGridView1.DataSource = e.Result;
				}
				catch (System.Reflection.TargetInvocationException err)
				{
					MessageBox.Show("An error occurred.");
				}
			}
			cmdCancel.Enabled = false;
            cmdGetEmployees.Enabled = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

			// Create the callback delegate.
			proxy.GetEmployeesSlowCompleted += new
			  GetEmployeesSlowCompletedEventHandler(this.GetEmployeesCompleted);

		}

		private void cmdCancel_Click(object sender, EventArgs e)
		{
			proxy.CancelAsync(requestID);
			MessageBox.Show("Operation cancelled.");
		}

	}
}