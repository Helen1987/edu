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

Imports System.Configuration
Imports System.Data.Services.Client
Imports System.Threading
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.StorageClient
Imports AzureDiagnostics

Module Module1

    Private lastPartitionKey As String = String.Empty
    Private lastRowKey As String = String.Empty

    Private Sub QueryLogTable(ByVal tableStorage As CloudTableClient)
        Dim context As TableServiceContext = tableStorage.GetDataServiceContext()
        Dim query As DataServiceQuery = TryCast(context.CreateQuery(Of LogEntry)(TableStorageTraceListener.DIAGNOSTICS_TABLE).Where(Function(entry) entry.PartitionKey.CompareTo(lastPartitionKey) > 0 OrElse (entry.PartitionKey = lastPartitionKey AndAlso entry.RowKey.CompareTo(lastRowKey) > 0)), DataServiceQuery)

        For Each entry As AzureDiagnostics.LogEntry In query.Execute()
            Console.WriteLine("{0} - {1}", entry.Timestamp, entry.Message)
            lastPartitionKey = entry.PartitionKey
            lastRowKey = entry.RowKey
        Next
    End Sub

    Public Sub Main(ByVal args() As String)
        Dim connectionString As String = If((args.Length = 0), "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString", args(0))

        Dim account As CloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings(connectionString))
        Dim tableStorage As CloudTableClient = account.CreateCloudTableClient()
        tableStorage.CreateTableIfNotExist(TableStorageTraceListener.DIAGNOSTICS_TABLE)

        Dim progress As New ProgressIndicator()
        Dim timer As New Timer(Sub(state)
                                   progress.Disable()
                                   QueryLogTable(tableStorage)
                                   progress.Enable()
                               End Sub, Nothing, 0, 10000)

        Console.ReadKey(True)
    End Sub

End Module
