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
Imports System.Activities.Tracking

Public Class TestTrackingParticipant
    Inherits TrackingParticipant
    Private m_records As New List(Of TrackingRecord)()

    Public ReadOnly Property Records() As List(Of TrackingRecord)
        Get
            Return m_records
        End Get
    End Property

    Protected Overrides Sub Track(ByVal record As TrackingRecord, ByVal timeout As TimeSpan)
        m_records.Add(record)
    End Sub
End Class
