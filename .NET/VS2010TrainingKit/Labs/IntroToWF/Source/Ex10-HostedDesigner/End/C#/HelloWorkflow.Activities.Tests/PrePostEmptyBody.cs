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

    public sealed class PrePostEmptyBody : Activity<string>
    {
        public const string PreMsgText = "Pre Activity Called Ordinal:{0}";
        public const string PostMsgText = "Post Activity Called  Ordinal:{0}";

        public OutArgument<string> PreMsg { get; set; }
        public OutArgument<string> PostMsg { get; set; }

        public PrePostEmptyBody()
        {
            base.Implementation = new Func<Activity>(CreateBody);
        }

        Activity CreateBody()
        {
            var Ordinal = new Variable<int> { Default = 1 };


            return new PrePostSequence()
            {
                Variables = { Ordinal },
                Pre = new Assign()
                {
                    To = new OutArgument<string>(env => this.PreMsg.Get(env)),
                    Value = new InArgument<string>((env) => string.Format(PreMsgText, Ordinal.Get(env)))
                },
                Post = new Sequence()
                {
                    Activities = {
                        new Assign()
                        {
                            // Increment the count
                            To = new OutArgument<int>(Ordinal),
                            Value = new InArgument<int>((env) => Ordinal.Get(env)+1) 
                        },
                        new Assign()
                        {
                            To = new OutArgument<string>(env => this.PostMsg.Get(env)),
                            Value = new InArgument<string>((env) => string.Format(PostMsgText, Ordinal.Get(env))) 
                        }
                    }
                }
            };
        }
    }
}
