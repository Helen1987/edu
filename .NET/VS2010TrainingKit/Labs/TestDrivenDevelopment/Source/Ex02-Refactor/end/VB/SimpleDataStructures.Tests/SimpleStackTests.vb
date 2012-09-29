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

Imports System.Text

<TestClass()> Public Class SimpleStackTests

    <TestMethod()> Public Sub ThenItShouldBeEmpty()
        Dim theStack As New SimpleStack()

        Assert.IsTrue(theStack.IsEmpty)
    End Sub

    <TestMethod()> Public Sub ThenShouldBeAbleToPushAnItemOntoTheStack()
        Dim theStack As New SimpleStack

        theStack.Push(1)
        Assert.IsFalse(theStack.IsEmpty)
    End Sub

    <TestMethod()> Public Sub ThenShouldBeAbleToPushAndPopAnItemFromTheStack()
        Dim theStack As New SimpleStack
        theStack.Push(1)
        Dim poppedItem As Integer = theStack.Pop()
        Assert.AreEqual(1, poppedItem)
    End Sub
End Class
