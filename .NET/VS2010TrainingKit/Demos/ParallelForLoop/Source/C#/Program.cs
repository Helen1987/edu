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
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParallelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MTID={0}", 
                Thread.CurrentThread.ManagedThreadId);

            Stopwatch sw = Stopwatch.StartNew();
            ParallelMethod();
            // NonParallelMethod();
            sw.Stop();

            Console.WriteLine("It Took {0} ms", 
                sw.ElapsedMilliseconds);

            Console.WriteLine("\nFinished...");
            Console.ReadKey(true);
        }

        static void NonParallelMethod()
        {
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine("TID={0}, i={1}",
                    Thread.CurrentThread.ManagedThreadId,
                    i);

                SimulateProcessing();
            }
        }

        static void ParallelMethod()
        {
            Parallel.For(0, 16, i =>
            {
                Console.WriteLine("TID={0}, i={1}",
                    Thread.CurrentThread.ManagedThreadId,
                    i);

                SimulateProcessing();
            });
        }

        static void SimulateProcessing()
        {
            Thread.SpinWait(80000000);
        }
    }
}
