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
using System.Web.Services;
using WebFormsSampleApp.Models;

namespace WebFormsSampleApp
{
    /// <summary>
    /// Summary description for GetProductImage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetProductImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int productId = Convert.ToInt32(context.Request["pid"]);
            AdventureWorksRepository repository = new AdventureWorksRepository();
            byte[] imageData = repository.GetProductImage(productId);

            context.Response.ContentType = "Image/gif";
            context.Response.OutputStream.Write(imageData, 0, imageData.Length);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}