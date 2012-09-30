using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsClient.localhost;
using WindowsClient.localhost1;

namespace WindowsClient
{
	public partial class Form1 : Form
	{
		private System.Net.CookieContainer cookieContainer =
	  new System.Net.CookieContainer();


		public Form1()
		{
			InitializeComponent();
		}

		private void cmdGetData_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			// Create the proxy.
			EmployeesService proxy = new EmployeesService();

			// Call the web service and get the results.
			DataSet ds = proxy.GetEmployees();

			// Bind the results.
			dataGridView1.DataSource = ds.Tables[0];

			this.Cursor = Cursors.Default;

		}

		private void cmdTestStateRight_Click(object sender, EventArgs e)
		{
			StatefulService proxy = new StatefulService();
			proxy.CookieContainer = cookieContainer;

			proxy.StoreName("John Smith");
			MessageBox.Show("You set: " + proxy.GetName());

		}

		private void cmdTestStateWrong_Click(object sender, EventArgs e)
		{
			// Create the proxy.
			StatefulService proxy = new StatefulService();


			// Set a name.
			proxy.StoreName("John Smith");

			// Try to retrieve the name.
			MessageBox.Show("You set: " + proxy.GetName());

		}
	}
}