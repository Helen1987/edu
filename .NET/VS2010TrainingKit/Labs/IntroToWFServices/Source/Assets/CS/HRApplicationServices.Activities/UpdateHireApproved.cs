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
using HRApplicationServices.Data;

namespace HRApplicationServices.Activities
{

    public sealed class UpdateHireApproved : CodeActivity
    {
        public InArgument<bool> HireApproved { get; set; }
        public InArgument<int> ApplicantID { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (HRApplicationDataEntities ctx = new HRApplicationDataEntities())
            {
                bool result = HireApproved.Get(context);
                int appID = ApplicantID.Get(context);

                var query = from a in ctx.Applicants
                            where a.ApplicationID == appID
                            select a;

                Applicant applicant = query.FirstOrDefault();
                applicant.HireApproved = result;

                ctx.SaveChanges();
            }
        }
    }
}
