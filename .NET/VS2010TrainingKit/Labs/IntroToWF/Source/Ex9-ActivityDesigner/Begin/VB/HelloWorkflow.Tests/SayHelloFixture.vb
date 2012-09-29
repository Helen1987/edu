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

<TestClass()> Public Class SayHelloFixture

    <TestMethod()> Public Sub ShouldReturnGreetingWithName()
        Dim output = WorkflowInvoker.Invoke( _
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
        Dim workflowApp As New WorkflowApplication( _
          New SayHello() With {.UserName = "Test"})

        workflowApp.Completed = _
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

        Debug.WriteLine("Test thread is " & _
              Thread.CurrentThread.ManagedThreadId)
        Debug.WriteLine("Workflow thread is " & outarg.ToString())
    End Sub

    <TestMethod()>
    Public Sub ShouldReturnGreetingWithOddLengthName()
        Dim output = WorkflowInvoker.Invoke( _
          New SayHello() With {.UserName = "Odd"})
        Assert.AreEqual("Greetings Odd from Workflow 4",
                output("Greeting").ToString())
    End Sub

    <TestMethod(), ExpectedException(GetType(ArgumentNullException))>
    Public Sub ShouldHandleNullUserName()

        ' Invoking with no arguments
        WorkflowInvoker.Invoke(New SayHello())

    End Sub

End Class
