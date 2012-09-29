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

Imports System.Threading

' A generic base class for IAsyncResult implementations that wraps a ManualResetEvent.
<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification := "Demo code")>
Public MustInherit Class AsyncResult
    Implements IAsyncResult
    Private callback As AsyncCallback
    Private endCalled As Boolean
    Private completeException As Exception
    Private _isCompleted As Boolean
    Private manualResetEvent As ManualResetEvent
    Private state As Object
    Private _thisLock As Object

    Private privateCompletedSynchronously As Boolean
    Public ReadOnly Property CompletedSynchronously As Boolean Implements IAsyncResult.CompletedSynchronously
        Get
            Return privateCompletedSynchronously
        End Get
    End Property

    Protected Sub New(ByVal callback As AsyncCallback, ByVal state As Object)
        Me.callback = callback
        Me.state = state
        Me._thisLock = New Object()
    End Sub

    Public ReadOnly Property AsyncState As Object Implements IAsyncResult.AsyncState
        Get
            Return Me.state
        End Get
    End Property

    Public ReadOnly Property AsyncWaitHandle As WaitHandle Implements IAsyncResult.AsyncWaitHandle
        Get
            If Me.manualResetEvent IsNot Nothing Then Return Me.manualResetEvent

            SyncLock Me.ThisLock
                If Me.manualResetEvent Is Nothing Then Me.manualResetEvent = New ManualResetEvent(Me._isCompleted)
            End SyncLock

            Return Me.manualResetEvent
        End Get
    End Property

    Public ReadOnly Property IsCompleted As Boolean Implements IAsyncResult.IsCompleted
        Get
            Return Me._isCompleted
        End Get
    End Property

    Private ReadOnly Property ThisLock As Object
        Get
            Return Me._thisLock
        End Get
    End Property

    ' End should be called when the End function for the asynchronous operation is complete.  It
    ' ensures the asynchronous operation is complete, and does some common validation.
    Protected Shared Function [End](Of TAsyncResult As AsyncResult)(ByVal result As IAsyncResult) As TAsyncResult
        If result Is Nothing Then Throw New ArgumentNullException("result")

        Dim asyncResult = TryCast(result, TAsyncResult)

        If asyncResult Is Nothing Then Throw New ArgumentException("Invalid async result.", "result")

        If asyncResult.endCalled Then Throw New InvalidOperationException("Async object already ended.")

        asyncResult.endCalled = True

        If Not asyncResult.IsCompleted Then asyncResult.AsyncWaitHandle.WaitOne()

        If asyncResult.manualResetEvent IsNot Nothing Then asyncResult.manualResetEvent.Close()

        If asyncResult.completeException IsNot Nothing Then Throw asyncResult.completeException

        Return asyncResult
    End Function

    ' Call this version of complete when your asynchronous operation is complete.  This will update the state
    ' of the operation and notify the callback.
    Protected Sub Complete(ByVal completedSynchronously As Boolean)

        ' It's a bug to call Complete twice.
        If Me._isCompleted Then Throw New InvalidOperationException("This async result is already completed.")

        Me.privateCompletedSynchronously = completedSynchronously

        If completedSynchronously Then
            Me._isCompleted = True
        Else
            SyncLock Me.ThisLock
                Me._isCompleted = True
                If Me.manualResetEvent IsNot Nothing Then Me.manualResetEvent.Set()
            End SyncLock
        End If

        ' If the callback throws, there is a bug in the callback implementation
        If Me.callback IsNot Nothing Then Me.callback(Me)
    End Sub

    ' Call this version of complete if you raise an exception during processing.  In addition to notifying
    ' the callback, it will capture the exception and store it to be thrown during AsyncResult.End.
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification := "Demo code")>
    Protected Sub Complete(ByVal completedSynchronously As Boolean, ByVal exception As Exception)
        Me.completeException = exception
        Me.Complete(completedSynchronously)
    End Sub
End Class