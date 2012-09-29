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

using HelloWorkflow.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Collections.ObjectModel;
using System.Activities.Statements;
using System.Collections.Generic;

namespace HelloWorkflow.Activities.Tests
{
    
    
    /// <summary>
    /// Test for PrePostSequence class
    ///</summary>
    [TestClass()]
    public class PrePostSequenceTest
    {

        [TestMethod()]
        public void ShouldInvokeEmptyPrePostSequence()
        {
            WorkflowInvoker.Invoke(new PrePostSequence());

            // Test passes if no exception
        }

        [TestMethod()]
        public void ShouldInvokePreOnly()
        {
            Activity target = new PreOnlyWorkflow();
            var output = WorkflowInvoker.Invoke(target);

            Assert.AreEqual(PreOnlyWorkflow.PreMsg, output["Result"]);
        }

        [TestMethod()]
        public void ShouldInvokePreAndPostEmptyBody()
        {
            Activity target = new PrePostEmptyBody();
            var output = WorkflowInvoker.Invoke(target);

            Assert.AreEqual(string.Format(PrePostEmptyBody.PreMsgText, 1), output["PreMsg"]);
            Assert.AreEqual(string.Format(PrePostEmptyBody.PostMsgText, 2), output["PostMsg"]);
        }

        [TestMethod()]
        public void ShouldInvokePreAndPostAndBody()
        {
            Activity target = new PrePostAndBody();
            var output = WorkflowInvoker.Invoke(target);

            Assert.AreEqual(string.Format(PrePostAndBody.PreMsgText, 1), output["PreMsg"]);

            List<string> bodyMsgs = (List<string>)output["BodyMsgs"];
            Assert.AreEqual(string.Format(PrePostAndBody.BodyMsgText, 2), bodyMsgs[0]);
            Assert.AreEqual(string.Format(PrePostAndBody.BodyMsgText, 3), bodyMsgs[1]);

            Assert.AreEqual(string.Format(PrePostAndBody.PostMsgText, 4), output["PostMsg"]);
        }

        [TestMethod()]
        public void ShouldInvokeNoPreAndPostAndBody()
        {
            Activity target = new NoPrePostAndBody();
            var output = WorkflowInvoker.Invoke(target);

            List<string> bodyMsgs = (List<string>)output["BodyMsgs"];
            Assert.AreEqual(string.Format(NoPrePostAndBody.BodyMsgText, 1), bodyMsgs[0]);
            Assert.AreEqual(string.Format(NoPrePostAndBody.BodyMsgText, 2), bodyMsgs[1]);

            Assert.AreEqual(string.Format(NoPrePostAndBody.PostMsgText, 3), output["PostMsg"]);
        }

        [TestMethod()]
        public void ShouldInvokeOnlyPost()
        {
            Activity target = new OnlyPost();
            var output = WorkflowInvoker.Invoke(target);
            Assert.AreEqual(string.Format(OnlyPost.PostMsgText, 1), output["PostMsg"]);
        }

        [TestMethod()]
        public void ShouldInvokeOnlyBody()
        {
            Activity target = new NoPrePostAndBody();
            var output = WorkflowInvoker.Invoke(target);

            List<string> bodyMsgs = (List<string>)output["BodyMsgs"];
            Assert.AreEqual(string.Format(NoPrePostAndBody.BodyMsgText, 1), bodyMsgs[0]);
            Assert.AreEqual(string.Format(NoPrePostAndBody.BodyMsgText, 2), bodyMsgs[1]);
        }

    }
}
