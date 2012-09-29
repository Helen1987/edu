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

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Activities
Imports HelloWorkflow.Activities
Imports System.Activities.Statements
Imports System.Activities.Expressions

Public NotInheritable Class NoPrePostAndBody
    Inherits Activity(Of String)
    Public Const PostMsgText As String = "Post Activity Called Ordinal:{0}"
    Public Const BodyMsgText As String = "Body Activity Called Ordinal:{0}"

    Private _PostMsg As OutArgument(Of String)
    Public Property PostMsg() As OutArgument(Of String)
        Get
            Return _PostMsg
        End Get
        Set(ByVal value As OutArgument(Of String))
            _PostMsg = value
        End Set
    End Property
    Private _BodyMsgs As OutArgument(Of ICollection(Of String))
    Public Property BodyMsgs() As OutArgument(Of ICollection(Of String))
        Get
            Return _BodyMsgs
        End Get
        Set(ByVal value As OutArgument(Of ICollection(Of String)))
            _BodyMsgs = value
        End Set
    End Property

    Public Sub New()
        MyBase.Implementation = New Func(Of Activity)(AddressOf CreateBody)
    End Sub

    Private Function CreateBody() As Activity
        Dim pps As New PrePostSequence
        Dim Ordinal = New Variable(Of Integer)() With {.[Default] = 1}
        pps.Variables.Add(Ordinal)

        Dim Messages As New Variable(Of ICollection(Of String))() With {
         .Name = "Messages",
         .[Default] = New LambdaValue(Of ICollection(Of String))(Function(ctx) New List(Of String)())
        }
        pps.Variables.Add(Messages)

        ' Add the message
        pps.Activities.Add(New AddToCollection(Of String)() With {
          .Collection = New InArgument(Of ICollection(Of String))(Function(ctx) Messages.[Get](ctx)),
          .Item = New InArgument(Of String)(Function(ctx) String.Format(BodyMsgText, Ordinal.[Get](ctx)))
         })

        ' Delay
        pps.Activities.Add(New Delay() With {.Duration = TimeSpan.FromMilliseconds(10)})

        ' Increment ordinal
        pps.Activities.Add(New Assign() With {
          .[To] = New OutArgument(Of Integer)(Ordinal),
          .Value = New InArgument(Of Integer)(Function(ctx) Ordinal.[Get](ctx) + 1)
         })

        ' Add the message
        pps.Activities.Add(New AddToCollection(Of String)() With {
          .Collection = New InArgument(Of ICollection(Of String))(Function(ctx) Messages.[Get](ctx)),
          .Item = New InArgument(Of String)(Function(ctx) String.Format(BodyMsgText, Ordinal.[Get](ctx)))
         })

        ' Update the out argument
        pps.Activities.Add(New Assign() With {
            .[To] = New OutArgument(Of ICollection(Of String))(Function(ctx) Me.BodyMsgs.[Get](ctx)),
            .Value = New InArgument(Of ICollection(Of String))(Function(ctx) Messages.[Get](ctx))})


        Dim postSequence = New Sequence

        ' Increment ordinal
        postSequence.Activities.Add(New Assign() With {
          .[To] = New OutArgument(Of Integer)(Ordinal),
          .Value = New InArgument(Of Integer)(Function(ctx) Ordinal.[Get](ctx) + 1)
         })

        ' Delay
        postSequence.Activities.Add(New Delay() With {.Duration = TimeSpan.FromMilliseconds(10)})

        ' Assign
        postSequence.Activities.Add(New Assign() With {
           .[To] = New OutArgument(Of String)(Function(ctx) Me.PostMsg.[Get](ctx)),
           .Value = New InArgument(Of String)(Function(ctx) String.Format(PostMsgText, Ordinal.[Get](ctx)))})

        pps.Post = postSequence

        Return pps
    End Function
End Class
