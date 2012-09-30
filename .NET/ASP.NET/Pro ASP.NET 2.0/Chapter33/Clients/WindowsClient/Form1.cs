using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsClient.localhost;
using System.Web.Services.Protocols;
using WindowsClient.localhost1;

namespace WindowsClient
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void cmdGetData_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			// Create the proxy.
			EmployeesService proxy = new EmployeesService();

			// Bind the results.
			dataGridView1.DataSource = proxy.GetEmployees();

			this.Cursor = Cursors.Default;

		}

		private void cmdError_Click(object sender, EventArgs e)
		{
			EmployeesService proxy = new EmployeesService();
			try
			{
				int count = proxy.GetEmployeesCountError();
			}
			catch (SoapException err)
			{
				MessageBox.Show("Original error was: " + err.Detail.InnerText);
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			SessionHeaderService proxy = new SessionHeaderService();
			proxy.CreateSession();
			proxy.SetSessionData(new DataSet("TestDataSet"));
			DataSet ds = proxy.GetSessionData();
			if (ds == null)
			{
				MessageBox.Show("Test Failed.");
			}
			else
			{
				MessageBox.Show("Retrieved DataSet " + ds.DataSetName);
			}
		}

		
	}
}