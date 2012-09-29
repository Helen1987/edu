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
using System.Activities.Statements;
using System.Diagnostics;
using System.Activities.Tracking;

namespace HelloWorkflow.Activities.Tests
{
    
    
    /// <summary>
    ///This is a test class for DiagnosticTraceTest and is intended
    ///to contain all DiagnosticTraceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DiagnosticTraceTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        const string TestTrace = "Test Trace";
        const string TestCategory = "Test";
        const string TestOutput = TestCategory + ": " + TestTrace;

        [TestMethod()]
        public void ShouldOutputVerboseTrace()
        {
            var targetWorkflow = GetVerboseTraceWorkflow();
            var listener = new TestTraceListener();
            var tracker = new TestTrackingParticipant();
            var profile = new TrackingProfile()
            {
                Name = "TestTrackingProfile",
                Queries = 
                {
                    new CustomTrackingQuery()
                    {
                        Name=TestCategory,
                        ActivityName = "*"
                    }
                }
            };

            tracker.TrackingProfile = profile;

            Trace.Listeners.Add(listener);

            var workflow = new WorkflowInvoker(targetWorkflow);
            workflow.Extensions.Add(tracker);

            workflow.Invoke();

            // Assert System.Diagnostics.Trace
            Assert.AreEqual(1, listener.Traces.Count);
            Assert.AreEqual(TestOutput, listener.Traces[0]);

            // Assert Tracking Records
            Assert.AreEqual(1, tracker.Records.Count);
            var customRecord = tracker.Records[0] as CustomTrackingRecord;
            Assert.AreEqual(TestTrace, customRecord.Data["Text"]);
            Assert.AreEqual(TestCategory, customRecord.Data["Category"]);
        }

        private static Activity GetVerboseTraceWorkflow()
        {
            return new Sequence()
            {
                Activities = 
                {
                    new DiagnosticTrace()
                    {
                        Text = TestTrace,
                        Category = TestCategory,
                        Level = TraceLevel.Verbose
                    }
                }
            };
        }
    }
}
