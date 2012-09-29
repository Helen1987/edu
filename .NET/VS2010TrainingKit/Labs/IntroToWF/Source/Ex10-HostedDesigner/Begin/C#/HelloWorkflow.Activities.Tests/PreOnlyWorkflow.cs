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
using HelloWorkflow.Activities;
using System.Activities.Statements;

namespace HelloWorkflow.Activities.Tests
{

    public sealed class PreOnlyWorkflow : Activity<string>
    {
        public const string PreMsg = "Pre Activity Called";

        public PreOnlyWorkflow()
        {
            base.Implementation = new Func<Activity>(CreateBody);
        }

        Activity CreateBody()
        {
            return new PrePostSequence()
            {
                Pre = new Assign() 
                { 
                    To = new OutArgument<string>(env => this.Result.Get(env)), 
                    Value = new InArgument<string>(PreMsg) 
                }
            };
        }
    }
}
