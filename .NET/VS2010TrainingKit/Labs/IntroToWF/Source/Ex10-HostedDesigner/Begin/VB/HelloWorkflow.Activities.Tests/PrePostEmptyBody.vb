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


Public NotInheritable Class PrePostEmptyBody
    Inherits Activity(Of String)
    Public Const PreMsgText As String = "Pre Activity Called Ordinal:{0}"
    Public Const PostMsgText As String = "Post Activity Called  Ordinal:{0}"

    Public Property PreMsg() As OutArgument(Of String)
        Get
            Return m_PreMsg
        End Get
        Set(ByVal value As OutArgument(Of String))
            m_PreMsg = value
        End Set
    End Property
    Private m_PreMsg As OutArgument(Of String)
    Public Property PostMsg() As OutArgument(Of String)
        Get
            Return m_PostMsg
        End Get
        Set(ByVal value As OutArgument(Of String))
            m_PostMsg = value
        End Set
    End Property
    Private m_PostMsg As OutArgument(Of String)

    Public Sub New()
        MyBase.Implementation = New Func(Of Activity)(AddressOf CreateBody)
    End Sub

    Private Function CreateBody() As Activity
        Dim pps As New PrePostSequence

        Dim Ordinal = New Variable(Of Integer)() With {.[Default] = 1}
        pps.Variables.Add(Ordinal)

        pps.Pre = New Assign() With {
          .[To] = New OutArgument(Of String)(Function(env) Me.PreMsg.[Get](env)),
          .Value = New InArgument(Of String)(Function(env) String.Format(PreMsgText, Ordinal.[Get](env)))
         }

        Dim postSequence = New Sequence()

        postSequence.Activities.Add(New Assign() With {
           .[To] = New OutArgument(Of Integer)(Ordinal),
           .Value = New InArgument(Of Integer)(Function(env) Ordinal.[Get](env) + 1)
          })

        postSequence.Activities.Add(New Assign() With {
           .[To] = New OutArgument(Of String)(Function(env) Me.PostMsg.[Get](env)),
           .Value = New InArgument(Of String)(Function(env) String.Format(PostMsgText, Ordinal.[Get](env)))
          })

        pps.Post = postSequence

        Return pps
    End Function
End Class
