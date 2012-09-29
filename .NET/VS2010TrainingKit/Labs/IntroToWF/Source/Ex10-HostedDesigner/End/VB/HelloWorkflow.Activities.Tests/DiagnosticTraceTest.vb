' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

Imports HelloWorkflow.Activities
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System
Imports System.Activities
Imports System.Activities.Statements
Imports System.Diagnostics
Imports System.Activities.Tracking

''' <summary>
'''This is a test class for DiagnosticTraceTest and is intended
'''to contain all DiagnosticTraceTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DiagnosticTraceTest


    Private testContextInstance As TestContext

    ''' <summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    ' 
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '[ClassInitialize()]
    'public static void MyClassInitialize(TestContext testContext)
    '{
    '}
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '[ClassCleanup()]
    'public static void MyClassCleanup()
    '{
    '}
    '
    'Use TestInitialize to run code before running each test
    '[TestInitialize()]
    'public void MyTestInitialize()
    '{
    '}
    '
    'Use TestCleanup to run code after each test has run
    '[TestCleanup()]
    'public void MyTestCleanup()
    '{
    '}
    '
#End Region

    Const TestTrace As String = "Test Trace"
    Const TestCategory As String = "Test"
    Const TestOutput As String = TestCategory + ": " + TestTrace

    <TestMethod()> _
    Public Sub ShouldOutputVerboseTrace()
        Dim targetWorkflow = GetVerboseTraceWorkflow()
        Dim listener = New TestTraceListener()
        Dim tracker = New TestTrackingParticipant()
        Dim profile = New TrackingProfile() With {.Name = "TestTrackingProfile"}

        profile.Queries.Add(New CustomTrackingQuery() With {.Name = TestCategory, .ActivityName = "*"})

        tracker.TrackingProfile = profile

        Trace.Listeners.Add(listener)

        Dim workflow = New WorkflowInvoker(targetWorkflow)
        workflow.Extensions.Add(tracker)

        workflow.Invoke()

        ' Assert System.Diagnostics.Trace
        Assert.AreEqual(1, listener.Traces.Count)
        Assert.AreEqual(TestOutput, listener.Traces(0))

        ' Assert Tracking Records
        Assert.AreEqual(1, tracker.Records.Count)
        Dim customRecord = TryCast(tracker.Records(0), CustomTrackingRecord)
        Assert.AreEqual(TestTrace, customRecord.Data("Text"))
        Assert.AreEqual(TestCategory, customRecord.Data("Category"))
    End Sub

    Private Shared Function GetVerboseTraceWorkflow() As Activity
        Dim sequence As New Sequence()
        sequence.Activities.Add(New DiagnosticTrace() With
                                {
                                    .Text = TestTrace,
                                    .Category = TestCategory,
                                    .Level = TraceLevel.Verbose
                                })
        Return sequence
    End Function
End Class
