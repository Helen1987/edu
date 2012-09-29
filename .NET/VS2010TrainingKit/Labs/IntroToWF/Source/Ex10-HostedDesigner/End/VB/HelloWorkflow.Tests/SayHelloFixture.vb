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

Imports System.Activities
Imports System.Text
Imports System.Threading
Imports System.Activities.Tracking
Imports HelloWorkflow.Activities.Tests

<TestClass()> Public Class SayHelloFixture

    <TestMethod()> Public Sub ShouldReturnGreetingWithName()
        Dim output = WorkflowInvoker.Invoke(
          New SayHello() With {.UserName = "Test"})
        Assert.AreEqual("Hello Test from Workflow 4", output("Greeting"))
    End Sub

    ''' <summary>
    ''' Verifies that the SayHello workflow contains an Out Argument
    ''' Name: WorkflowThread
    ''' Type: Int32
    ''' Value: Non-Zero, matches thread used for Completed action
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()> Public Sub ShouldReturnWorkflowThread()
        Dim sync As New AutoResetEvent(False)
        Dim actionThreadID As Int32 = 0
        Dim output As IDictionary(Of String, Object) = Nothing
        Dim workflowApp As New WorkflowApplication(
          New SayHello() With {.UserName = "Test"})

        workflowApp.Completed =
          Function(e)
              output = e.Outputs
              actionThreadID = Thread.CurrentThread.ManagedThreadId

              ' Signal the test thread the workflow is done
              sync.Set()

              ' VB requires a lambda expression to return a value
              ' It is not used with Action(Of T)
              Return Nothing
          End Function

        workflowApp.Run()

        ' Wait for the sync event for 1 second
        sync.WaitOne(TimeSpan.FromSeconds(1))

        Assert.IsNotNull(output, "output not set, workflow may have timed out")

        Assert.IsTrue(output.ContainsKey("WorkflowThread"),
               "SayHello must contain an OutArgument named WorkflowThread")

        ' Don't know for sure what it is yet
        Dim outarg = output("WorkflowThread")

        Assert.IsInstanceOfType(outarg, GetType(Int32),
                  "WorkflowThread must be of type Int32")

        Assert.AreNotEqual(0, output("WorkflowThread"),
                  "WorkflowThread must not be zero")

        Debug.WriteLine("Test thread is " &
              Thread.CurrentThread.ManagedThreadId)
        Debug.WriteLine("Workflow thread is " & outarg.ToString())
    End Sub

    <TestMethod()>
    Public Sub ShouldReturnGreetingWithOddLengthName()
        Dim output = WorkflowInvoker.Invoke(
          New SayHello() With {.UserName = "Odd"})
        Assert.AreEqual("Greetings Odd from Workflow 4",
                output("Greeting").ToString())
    End Sub

    <TestMethod(), ExpectedException(GetType(ArgumentNullException))>
    Public Sub ShouldHandleNullUserName()

        ' Invoking with no arguments
        WorkflowInvoker.Invoke(New SayHello())

    End Sub

    <TestMethod()>
    Public Sub ShouldOutputVerboseTrace()
        ' Arrange
        Dim testCategory As String = "Test"
        Dim expectedData As String = "From SayHello"
        Dim expectedTrace As String = String.Format("{0}: {1}", testCategory, expectedData)
        Dim listener = New TestTraceListener()
        Dim tracker = New TestTrackingParticipant()
        Dim profile = New TrackingProfile() With {.Name = "TestTrackingProfile"}

        profile.Queries.Add(New CustomTrackingQuery() With {.Name = testCategory, .ActivityName = "*"})

        tracker.TrackingProfile = profile

        Trace.Listeners.Add(listener)

        Dim target = New SayHello() With {.UserName = "Test"}

        Dim workflow = New WorkflowInvoker(target)
        workflow.Extensions.Add(tracker)

        ' Act
        workflow.Invoke()

        ' Assert System.Diagnostics.Trace
        Assert.AreEqual(1, listener.Traces.Count)
        Assert.AreEqual(expectedTrace, listener.Traces(0))

        ' Assert Tracking Records
        Assert.AreEqual(1, tracker.Records.Count)
        Dim customRecord = TryCast(tracker.Records(0), CustomTrackingRecord)
        Assert.AreEqual(expectedData, customRecord.Data("Text"))
        Assert.AreEqual(testCategory, customRecord.Data("Category"))
    End Sub

    <TestMethod()>
    Public Sub ShouldReturnPrePostMessages()
        Dim output As IDictionary(Of String, Object)

        output = WorkflowInvoker.Invoke(New SayHello() With {.UserName = "Test"})

        Assert.AreEqual("This is Pre-Sequence Ordinal:1", output("PreMessage"))
        Assert.AreEqual("PrePost is Cool Ordinal:2", output("PrePostBody"))
        Assert.AreEqual("This is Post-Sequence Ordinal:3", output("PostMessage"))
    End Sub

End Class
