﻿// ----------------------------------------------------------------------------------
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
using System.Activities.Expressions;

namespace HelloWorkflow.Activities.Tests
{

    public sealed class OnlyBody : Activity<string>
    {
        public const string BodyMsgText = "Body Activity Called  Ordinal:{0}";

        public OutArgument<ICollection<string>> BodyMsgs { get; set; }

        public OnlyBody()
        {
            base.Implementation = new Func<Activity>(CreateBody);
        }

        Activity CreateBody()
        {
            var Ordinal = new Variable<int> { Default = 1 };
            var Messages = new Variable<ICollection<string>>()
            {
                Name = "Messages",
                Default = new LambdaValue<ICollection<string>>(ctx => new List<string>()),
            };

            return new PrePostSequence()
            {
                Variables = { Ordinal, Messages },
                Activities = 
                {
                    new AddToCollection<string>()
                    {
                        Collection = new InArgument<ICollection<string>>((ctx) => Messages.Get(ctx)),
                        Item = new InArgument<string>((ctx) => string.Format(BodyMsgText, Ordinal.Get(ctx))) 
                    },
                    new Assign()
                    {
                        // Increment the ordinal
                        To = new OutArgument<int>(Ordinal),
                        Value = new InArgument<int>((ctx) => Ordinal.Get(ctx)+1) 
                    },
                    new AddToCollection<string>()
                    {
                        Collection = new InArgument<ICollection<string>>((ctx) => Messages.Get(ctx)),
                        Item = new InArgument<string>((ctx) => string.Format(BodyMsgText, Ordinal.Get(ctx))) 
                    },
                    new Assign()
                    {
                        // Update the out argument
                        To = new OutArgument<ICollection<string>>(ctx => this.BodyMsgs.Get(ctx)),
                        Value = new InArgument<ICollection<string>>((ctx) => Messages.Get(ctx)) 
                    },

                },
            };
        }
    }
}