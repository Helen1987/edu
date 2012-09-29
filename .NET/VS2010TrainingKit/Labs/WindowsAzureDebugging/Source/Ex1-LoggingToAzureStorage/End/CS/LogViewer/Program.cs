// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Services.Client;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using AzureDiagnostics;

namespace LogViewer
{
    class Program
    {
        private static string lastPartitionKey = String.Empty;
        private static string lastRowKey = String.Empty;

        private static void QueryLogTable(CloudTableClient tableStorage)
        {
            TableServiceContext context = tableStorage.GetDataServiceContext();
            DataServiceQuery query = context.CreateQuery<LogEntry>(TableStorageTraceListener.DIAGNOSTICS_TABLE)
                                            .Where(entry => entry.PartitionKey.CompareTo(lastPartitionKey) > 0 
                                               || (entry.PartitionKey == lastPartitionKey && entry.RowKey.CompareTo(lastRowKey) > 0)) 
                                                as DataServiceQuery;

            foreach (AzureDiagnostics.LogEntry entry in query.Execute())
            {
                Console.WriteLine("{0} - {1}", entry.Timestamp, entry.Message);
                lastPartitionKey = entry.PartitionKey;
                lastRowKey = entry.RowKey;
            }
        }
        
        static void Main(string[] args)
        {
            string connectionString = (args.Length == 0) ? "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" : args[0];

            CloudStorageAccount account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings[connectionString]);
            CloudTableClient tableStorage = account.CreateCloudTableClient();
            tableStorage.CreateTableIfNotExist(TableStorageTraceListener.DIAGNOSTICS_TABLE);

            Utils.ProgressIndicator progress = new Utils.ProgressIndicator();
            Timer timer = new Timer((state) =>
            {
                progress.Disable();
                QueryLogTable(tableStorage);
                progress.Enable();
            }, null, 0, 10000);

            Console.ReadKey(true);
        }
    }
}
