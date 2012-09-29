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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CustomerViewer.Web.CustomerService.Proxies;

namespace CustomerViewer.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var proxy = new CustomerServiceClient();
            try
            {
                CustomersDropDownList.DataSource = proxy.GetCustomers();
                CustomersDropDownList.DataBind();
            }
            catch (Exception exp)
            {
                ShowAlert("Error fetching customers: " + exp.Message);
            }
        }

        private void ShowAlert(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(),
                   "ErrorScript",
                   "<script type='text/javascript'>alert(\"" + msg + "\");</script>");
        }
    }
}
