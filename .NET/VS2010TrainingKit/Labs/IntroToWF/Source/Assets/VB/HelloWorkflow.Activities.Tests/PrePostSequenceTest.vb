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
Imports System.Collections.ObjectModel
Imports System.Activities.Statements
Imports System.Collections.Generic

''' <summary>
''' Test for PrePostSequence class
'''</summary>
<TestClass()> _
Public Class PrePostSequenceTest

    <TestMethod()> _
    Public Sub ShouldInvokeEmptyPrePostSequence()
        WorkflowInvoker.Invoke(New PrePostSequence())

        ' Test passes if no exception
    End Sub

    <TestMethod()> _
    Public Sub ShouldInvokePreOnly()
        Dim target As Activity = New PreOnlyWorkflow()
        Dim output = WorkflowInvoker.Invoke(target)

        Assert.AreEqual(PreOnlyWorkflow.PreMsg, output("Result"))
    End Sub

    <TestMethod()> _
    Public Sub ShouldInvokePreAndPostEmptyBody()
        Dim target As Activity = New PrePostEmptyBody()
        Dim output = WorkflowInvoker.Invoke(target)

        Assert.AreEqual(String.Format(PrePostEmptyBody.PreMsgText, 1), output("PreMsg"))
        Assert.AreEqual(String.Format(PrePostEmptyBody.PostMsgText, 2), output("PostMsg"))
    End Sub

    <TestMethod()> _
    Public Sub ShouldInvokePreAndPostAndBody()
        Dim target As Activity = New PrePostAndBody()
        Dim output = WorkflowInvoker.Invoke(target)

        Assert.AreEqual(String.Format(PrePostAndBody.PreMsgText, 1), output("PreMsg"))

        Dim bodyMsgs As List(Of String) = DirectCast(output("BodyMsgs"), List(Of String))
        Assert.AreEqual(String.Format(PrePostAndBody.BodyMsgText, 2), bodyMsgs(0))
        Assert.AreEqual(String.Format(PrePostAndBody.BodyMsgText, 3), bodyMsgs(1))

        Assert.AreEqual(String.Format(PrePostAndBody.PostMsgText, 4), output("PostMsg"))
    End Sub

    <TestMethod()> _
    Public Sub ShouldInvokeNoPreAndPostAndBody()
        Dim target As Activity = New NoPrePostAndBody()
        Dim output = WorkflowInvoker.Invoke(target)

        Dim bodyMsgs As List(Of String) = DirectCast(output("BodyMsgs"), List(Of String))
        Assert.AreEqual(String.Format(NoPrePostAndBody.BodyMsgText, 1), bodyMsgs(0))
        Assert.AreEqual(String.Format(NoPrePostAndBody.BodyMsgText, 2), bodyMsgs(1))

        Assert.AreEqual(String.Format(NoPrePostAndBody.PostMsgText, 3), output("PostMsg"))
    End Sub

    <TestMethod()> _
    Public Sub ShouldInvokeOnlyPost()
        Dim target As Activity = New OnlyPost()
        Dim output = WorkflowInvoker.Invoke(target)
        Assert.AreEqual(String.Format(OnlyPost.PostMsgText, 1), output("PostMsg"))
    End Sub

    <TestMethod()> _
    Public Sub ShouldInvokeOnlyBody()
        Dim target As Activity = New NoPrePostAndBody()
        Dim output = WorkflowInvoker.Invoke(target)

        Dim bodyMsgs As List(Of String) = DirectCast(output("BodyMsgs"), List(Of String))
        Assert.AreEqual(String.Format(NoPrePostAndBody.BodyMsgText, 1), bodyMsgs(0))
        Assert.AreEqual(String.Format(NoPrePostAndBody.BodyMsgText, 2), bodyMsgs(1))
    End Sub

End Class
