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

' An AsyncResult that completes as soon as it is instantiated.
Public Class CompletedAsyncResult
    Inherits AsyncResult
    Public Sub New(ByVal callback As AsyncCallback, ByVal state As Object)
        MyBase.New(callback, state)
        Complete(True)
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification:="Demo code")>
    Public Overloads Shared Sub [End](ByVal result As IAsyncResult)
        AsyncResult.End(Of CompletedAsyncResult)(result)
    End Sub
End Class

Public Class CompletedAsyncResult(Of T)
    Inherits AsyncResult
    Private data As T

    Public Sub New(ByVal data As T, ByVal callback As AsyncCallback, ByVal state As Object)
        MyBase.New(callback, state)
        Me.data = data
        MyBase.Complete(True)
    End Sub


    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification:="Demo code")>
        Public Overloads Shared Function [End](ByVal result As IAsyncResult) As T
        Return AsyncResult.End(Of CompletedAsyncResult(Of T))(result).data
    End Function
End Class