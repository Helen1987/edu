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
using System.Activities;
using HRApplicationServices.Contracts;
using HRApplicationServices.Data;

namespace HRApplicationServices.Activities
{
    public class SaveJobApplication : CodeActivity<SubmitJobApplicationResponse>
    {
        public InArgument<SubmitJobApplicationRequest> AppRequest { get; set; }


        protected override SubmitJobApplicationResponse Execute(CodeActivityContext context)
        {
            using (HRApplicationDataEntities ctx = new HRApplicationDataEntities())
            {
                SubmitJobApplicationRequest request = AppRequest.Get(context);
                Applicant app = ctx.Applicants.CreateObject();
                app.ApplicantName = request.Resume.Name;
                app.NumberOfReferences = request.Resume.NumReferences;
                app.Education = request.Resume.Education;
                app.RequestID = request.RequestID;

                ctx.Applicants.AddObject(app);
                ctx.SaveChanges();
                ctx.Connection.Close();

                return new SubmitJobApplicationResponse()
                {
                    ApplicationID = app.ApplicationID,
                    ApplicantName = request.Resume.Name,
                    ResponseText = string.Format(ServiceResources.JobApplicationProcessing, request.Resume.Name, app.ApplicationID)
                };
            }
        }
    }
}