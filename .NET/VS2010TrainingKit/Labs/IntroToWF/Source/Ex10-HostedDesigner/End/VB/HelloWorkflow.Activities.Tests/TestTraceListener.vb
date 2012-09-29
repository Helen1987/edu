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
Imports System.Diagnostics

Public Class TestTraceListener
    Inherits TraceListener
    Private m_traces As New List(Of String)()

    Public ReadOnly Property Traces() As List(Of String)
        Get
            Return m_traces
        End Get
    End Property

    Public Overrides Sub Write(ByVal message As String)
        m_traces.Add(message)
    End Sub

    Public Overrides Sub WriteLine(ByVal message As String)
        Write(message)
    End Sub
End Class
