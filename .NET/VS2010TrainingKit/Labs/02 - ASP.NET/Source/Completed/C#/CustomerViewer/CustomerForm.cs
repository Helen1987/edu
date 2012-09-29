// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomerViewer.CustomerService.Proxies;


namespace CustomerViewer
{
    public partial class CustomerForm : Form
    {
        BindingSource _BindingSource;
        CustomerServiceClient _Proxy;

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            _Proxy = new CustomerServiceClient();
            try
            {
                _Proxy.GetCustomersCompleted += (s, args) =>
                    {
                        var custs = args.Result;
                        if (custs != null)
                            SetBindings(custs);
                        else
                            ShowMessageBox("No customers found.");
                    };
                _Proxy.GetCustomersAsync();
            }
            catch (Exception exp)
            {
                ShowMessageBox("Error fetching customers: " + exp.Message);
            }
        }

        private void SetBindings(List<Customer> custs)
        {
            _BindingSource = new BindingSource(custs, null);
            CustomersComboBox.DataSource = _BindingSource;
            CustomerIDLabel.DataBindings.Add("Text", _BindingSource, "CustomerID");
            FirstNameTextBox.DataBindings.Add("Text", _BindingSource, "FirstName");
            LastNameTextBox.DataBindings.Add("Text", _BindingSource, "LastName");
            CompanyNameTextBox.DataBindings.Add("Text", _BindingSource, "CompanyName");
            EmailTextBox.DataBindings.Add("Text", _BindingSource, "EmailAddress");
            PhoneTextBox.DataBindings.Add("Text", _BindingSource, "Phone");
            CustomerDetailsGroupBox.Visible = true;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string msg;
            var cust = CustomersComboBox.SelectedItem as Customer;
            cust.ChangeTracker.State = ObjectState.Modified;
            try
            {
                OperationStatus opStatus = _Proxy.SaveCustomer(cust);
                _BindingSource.ResetCurrentItem();
                msg = (opStatus.Status) ? "Customer Updated!" : "Unable to update Customer: " + opStatus.Message;
            }
            catch (Exception exp)
            {
                msg = "Error updating Customer: " + exp.Message;
            }

            ShowMessageBox(msg);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Customer?", "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string msg;
                var cust = CustomersComboBox.SelectedItem as Customer;
                cust.ChangeTracker.State = ObjectState.Deleted;
                try
                {
                    OperationStatus opStatus = _Proxy.SaveCustomer(cust);
                    if (opStatus.Status)
                    {
                        _BindingSource.Remove(cust);
                        msg = "Customer deleted!";
                    }
                    else
                    {
                        msg = "Unable to delete Customer: " + opStatus.Message;
                    }
                }
                catch (Exception exp)
                {
                    msg = "Error deleting Customer: " + exp.Message;
                }
                
                ShowMessageBox(msg);
            }
        }

        private void ShowMessageBox(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
