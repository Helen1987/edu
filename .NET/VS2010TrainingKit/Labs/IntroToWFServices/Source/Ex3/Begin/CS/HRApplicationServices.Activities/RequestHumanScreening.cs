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
using System.Text;
using System.Activities;
using HRApplicationServices.Contracts;
using System.Net.Mail;
using System.ServiceModel;
using System.Web.Configuration;
using System.Windows.Markup;
using System.Web.Hosting;

namespace HRApplicationServices.Activities
{

    public sealed class RequestHumanScreening : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<SubmitJobApplicationRequest> ApplicationRequest { get; set; }
        public InArgument<int> ApplicationID { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string baseURI = WebConfigurationManager.AppSettings["BaseURI"];
           
            if (string.IsNullOrEmpty(baseURI))
                throw new InvalidOperationException("No baseURI appSetting found in web.config");

            SmtpClient smtpClient = new SmtpClient();
            string applicant = ApplicationRequest.Get(context).Resume.Name;
            string htmlMailText = string.Format(ServiceResources.ReviewMailTemplate, applicant, ApplicationID.Get(context), baseURI);

            MailMessage msg = new MailMessage("admin@contoso.com", "hr@contoso.com",
                string.Format(ServiceResources.HumanScreenSubject, applicant), htmlMailText);
            msg.IsBodyHtml = true;

            smtpClient.Send(msg);
        }
    }
}
