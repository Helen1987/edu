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
Imports System.Data.Services.Client
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient

Public Class TableStorageTraceListener
    Inherits TraceListener
    Private Const DEFAULT_DIAGNOSTICS_CONNECTION_STRING = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString"

    Public Shared ReadOnly DIAGNOSTICS_TABLE = "DevLogsTable"

    <ThreadStatic()>
    Private Shared messageBuffer As StringBuilder

    Private initializationSection As New Object()
    Private isInitialized As Boolean = False

    Private traceLogAccess As New Object()
    Private traceLog As New List(Of LogEntry)()

    Private tableStorage As CloudTableClient
    Private connectionString As String

    Public Sub New()
        Me.New(DEFAULT_DIAGNOSTICS_CONNECTION_STRING)
    End Sub

    Public Sub New(ByVal connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Overrides ReadOnly Property IsThreadSafe() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Write(ByVal message As String)
        If TableStorageTraceListener.messageBuffer Is Nothing Then
            TableStorageTraceListener.messageBuffer = New StringBuilder()
        End If

        TableStorageTraceListener.messageBuffer.Append(message)
    End Sub

    Public Overrides Sub WriteLine(ByVal message As String)
        If TableStorageTraceListener.messageBuffer Is Nothing Then
            TableStorageTraceListener.messageBuffer = New StringBuilder()
        End If

        TableStorageTraceListener.messageBuffer.AppendLine(message)
    End Sub

    Public Overrides Sub Flush()
        If (Not Me.isInitialized) Then
            SyncLock Me.initializationSection
                If (Not Me.isInitialized) Then
                    Initialize()
                End If
            End SyncLock
        End If

        Dim context As TableServiceContext = tableStorage.GetDataServiceContext()
        context.MergeOption = MergeOption.AppendOnly
        SyncLock Me.traceLogAccess
            Me.traceLog.ForEach(Sub(entry) context.AddObject(DIAGNOSTICS_TABLE, entry))
            Me.traceLog.Clear()
        End SyncLock

        If context.Entities.Count > 0 Then
            context.BeginSaveChangesWithRetries(SaveChangesOptions.None, Sub(ar) context.EndSaveChangesWithRetries(ar), Nothing)
        End If
    End Sub

    Public Overrides Sub TraceData(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal eventType As TraceEventType, ByVal id As Integer, ByVal data As Object)
        MyBase.TraceData(eventCache, source, eventType, id, data)
        AppendEntry(id, eventType, eventCache)
    End Sub

    Public Overrides Sub TraceData(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal eventType As TraceEventType, ByVal id As Integer, ByVal ParamArray data() As Object)
        MyBase.TraceData(eventCache, source, eventType, id, data)
        AppendEntry(id, eventType, eventCache)
    End Sub

    Public Overrides Sub TraceEvent(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal eventType As TraceEventType, ByVal id As Integer)
        MyBase.TraceEvent(eventCache, source, eventType, id)
        AppendEntry(id, eventType, eventCache)
    End Sub

    Public Overrides Sub TraceEvent(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal eventType As TraceEventType, ByVal id As Integer, ByVal format As String, ByVal ParamArray args() As Object)
        MyBase.TraceEvent(eventCache, source, eventType, id, format, args)
        AppendEntry(id, eventType, eventCache)
    End Sub

    Public Overrides Sub TraceEvent(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal eventType As TraceEventType, ByVal id As Integer, ByVal message As String)
        MyBase.TraceEvent(eventCache, source, eventType, id, message)
        AppendEntry(id, eventType, eventCache)
    End Sub

    Public Overrides Sub TraceTransfer(ByVal eventCache As TraceEventCache, ByVal source As String, ByVal id As Integer, ByVal message As String, ByVal relatedActivityId As Guid)
        MyBase.TraceTransfer(eventCache, source, id, message, relatedActivityId)
        AppendEntry(id, TraceEventType.Transfer, eventCache)
    End Sub

    Private Sub Initialize()
        Dim account As CloudStorageAccount = CloudStorageAccount.FromConfigurationSetting(Me.connectionString)
        Me.tableStorage = account.CreateCloudTableClient()
        Me.tableStorage.CreateTableIfNotExist(DIAGNOSTICS_TABLE)
        Me.isInitialized = True
    End Sub

    Private Sub AppendEntry(ByVal id As Integer, ByVal eventType As TraceEventType, ByVal eventCache As TraceEventCache)
        If TableStorageTraceListener.messageBuffer Is Nothing Then
            TableStorageTraceListener.messageBuffer = New StringBuilder()
        End If

        Dim message As String = TableStorageTraceListener.messageBuffer.ToString()
        TableStorageTraceListener.messageBuffer.Length = 0

        If message.EndsWith(Environment.NewLine) Then
            message = message.Substring(0, message.Length - Environment.NewLine.Length)
        End If

        If message.Length = 0 Then
            Return
        End If

        Dim entry As New LogEntry() With {
            .PartitionKey = String.Format("{0:D10}", eventCache.Timestamp >> 30),
            .RowKey = String.Format("{0:D19}", eventCache.Timestamp),
            .EventTickCount = eventCache.Timestamp,
            .Level = CInt(Fix(eventType)),
            .EventId = id,
            .Pid = eventCache.ProcessId,
            .Tid = eventCache.ThreadId,
            .Message = message}

        SyncLock Me.traceLogAccess
            Me.traceLog.Add(entry)
        End SyncLock
    End Sub
End Class