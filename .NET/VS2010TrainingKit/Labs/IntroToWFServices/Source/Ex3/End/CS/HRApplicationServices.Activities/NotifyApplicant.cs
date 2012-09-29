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
using System.Web.Configuration;
namespace HRApplicationServices.Activities
{

    public sealed class NotifyApplicant : CodeActivity
    {
        public InArgument<bool> Hire { get; set; }
        public InArgument<ApplicantResume> Resume { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            bool hire = Hire.Get(context);
            ApplicantResume resume = Resume.Get(context);
            string baseURI = WebConfigurationManager.AppSettings["BaseURI"];

            if (string.IsNullOrEmpty(baseURI))
                throw new InvalidOperationException("No baseURI appSetting found in web.config");

            string htmlMailText;

            if (hire)
            {
                htmlMailText = string.Format(ServiceResources.GenericMailTemplate,
                    ServiceResources.HireHeading,
                    string.Format(ServiceResources.OfferText, resume.Name),baseURI);
            }
            else
            {
                htmlMailText = string.Format(ServiceResources.GenericMailTemplate,
                    ServiceResources.NoHireHeading,
                    string.Format(ServiceResources.NoHireText, resume.Name), baseURI);
            }

            SmtpClient smtpClient = new SmtpClient();

            MailMessage msg = new MailMessage("admin@contoso.com", resume.Email,
                string.Format(ServiceResources.ApplicationMailSubject), htmlMailText);
            msg.IsBodyHtml = true;

            smtpClient.Send(msg);
        }
    }
}
