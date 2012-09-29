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
    using System.Activities.Tracking;
    using HelloWorkflow.Activities.Tests;

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

        [TestMethod]
        public void ShouldReturnGreetingWithOddLengthName()
        {
            var output = WorkflowInvoker.Invoke(
              new SayHello() { UserName = "Odd" });

            string greeting = output["Greeting"].ToString();

            Assert.AreEqual("Greetings Odd from Workflow 4", greeting);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldHandleNullUserName()
        {
            // Invoking with no arguments
            WorkflowInvoker.Invoke(new SayHello());
        }

        [TestMethod()]
        public void ShouldOutputVerboseTrace()
        {
            // Arrange
            string testCategory = "Test";
            string expectedData = "From SayHello";
            string expectedTrace = string.Format("{0}: {1}", testCategory, expectedData);
            var listener = new TestTraceListener();
            var tracker = new TestTrackingParticipant();
            var profile = new TrackingProfile()
            {
                Name = "TestTrackingProfile",
                Queries = 
                {
                    new CustomTrackingQuery()
                    {
                        Name="Test",
                        ActivityName = "*"
                    }
                }
            };

            tracker.TrackingProfile = profile;

            Trace.Listeners.Add(listener);

            var target = new SayHello()
            {
                UserName = "Test"
            };

            var workflow = new WorkflowInvoker(target);
            workflow.Extensions.Add(tracker);

            // Act
            workflow.Invoke();

            // Assert System.Diagnostics.Trace
            Assert.AreEqual(1, listener.Traces.Count);
            Assert.AreEqual(expectedTrace, listener.Traces[0]);

            // Assert Tracking Records
            Assert.AreEqual(1, tracker.Records.Count);
            var customRecord = tracker.Records[0] as CustomTrackingRecord;
            Assert.AreEqual(expectedData, customRecord.Data["Text"]);
            Assert.AreEqual(testCategory, customRecord.Data["Category"]);
        }

        [TestMethod]
        public void ShouldReturnPrePostMessages()
        {
            IDictionary<string, object> output;

            output = WorkflowInvoker.Invoke(new SayHello()
            {
                UserName = "Test"
            });

            Assert.AreEqual("This is Pre-Sequence Ordinal:1", output["PreMessage"]);
            Assert.AreEqual("PrePost is Cool Ordinal:2", output["PrePostBody"]);
            Assert.AreEqual("This is Post-Sequence Ordinal:3", output["PostMessage"]);
        }

    }
}
