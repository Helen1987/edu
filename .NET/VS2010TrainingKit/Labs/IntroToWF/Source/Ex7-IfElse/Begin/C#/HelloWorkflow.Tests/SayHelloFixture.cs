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

namespace HelloWorkflow.Tests
{
    using System;
    using System.Activities;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SayHelloFixture
    {
        [TestMethod]
        public void ShouldReturnGreetingWithName()
        {
            var output = WorkflowInvoker.Invoke(
              new SayHello()
              {
                  UserName = "Test"
              });
            Assert.AreEqual("Hello Test from Workflow 4", output["Greeting"]);
        }

        /// <summary>
        /// Verifies that the workflow returns an Out Argument
        /// Name: WorkflowThread
        /// Type: Int32
        /// Value: Non-Zero, matches thread used for Completed action
        /// </summary>
        [TestMethod]
        public void ShouldReturnWorkflowThread()
        {
            AutoResetEvent sync = new AutoResetEvent(false);
            Int32 actionThreadID = 0;
            IDictionary<string, object> output = null;

            WorkflowApplication workflowApp =
              new WorkflowApplication(
                   new SayHello()
                   {
                       UserName = "Test"
                   });

            // Create an Action<T> using a lambda expression
            // To be invoked when the workflow completes
            workflowApp.Completed = (e) =>
            {
                output = e.Outputs;
                actionThreadID = Thread.CurrentThread.ManagedThreadId;

                // Signal the test thread the workflow is done
                sync.Set();
            };

            workflowApp.Run();

            // Wait for the sync event for 1 second
            sync.WaitOne(TimeSpan.FromSeconds(1));

            Assert.IsNotNull(output,
              "output not set, workflow may have timed out");

            Assert.IsTrue(output.ContainsKey("WorkflowThread"),
              "SayHello must contain an OutArgument named WorkflowThread");

            // Don't know for sure what it is yet
            var outarg = output["WorkflowThread"];

            Assert.IsInstanceOfType(outarg, typeof(Int32),
              "WorkflowThread must be of type Int32");

            Assert.AreNotEqual(0, outarg,
              "WorkflowThread must not be zero");

            Debug.WriteLine("Test thread is " +
                    Thread.CurrentThread.ManagedThreadId);
            Debug.WriteLine("Workflow thread is " + outarg.ToString());
        }
    }
}
