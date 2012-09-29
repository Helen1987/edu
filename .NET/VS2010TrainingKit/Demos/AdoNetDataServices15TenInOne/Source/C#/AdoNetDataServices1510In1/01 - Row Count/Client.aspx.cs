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
using System.Data.Services.Client;

namespace AdoNetDataServices1510In1.RowCount
{
    public partial class Client : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceProxies.RowCountContext context = new ServiceProxies.RowCountContext(new Uri("http://localhost:50000/01%20-%20Row%20Count/RowCountService.svc"));

            // This query requests all products as well as the total count
            // of products (included inline). This is equivalent to:
            // RowCountService.svc/Products?$inlinecount=allpages
            var productsWithCount = from prod in context.Products.IncludeTotalCount()
                                    orderby prod.Name
                                    select prod;

            var queryResponse = (productsWithCount as DataServiceQuery).Execute();
            var queryOperationResponse = queryResponse as QueryOperationResponse;
            var inlineCount = queryOperationResponse.TotalCount;

            // This query requests only the count of all products
            // on the server. This is equivalent to: 
            // RowCountService.svc/Products/$count
            var productCount = context.Products.Count();
            rowCountLabel.Text = productCount.ToString();
        }
    }
}