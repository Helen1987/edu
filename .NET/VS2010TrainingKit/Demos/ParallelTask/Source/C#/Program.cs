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
using System.Threading.Tasks;
using System.Diagnostics;

namespace TaskSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MTID={0}", Thread.CurrentThread.ManagedThreadId);

            // RunTasks();
            // RunThreads();
            RunPool();

            // More work
            Console.ReadKey(true);
        }

        static void DoSomeWork(object state)
        {
            int loops = (int)state * 25000000;
            for (int i = 0; i < loops; i++) { i++; i--; i *= 1; }

            Console.WriteLine("TID={0}, state={1}",
                Thread.CurrentThread.ManagedThreadId,
                state);
        }

        static void RunThreads()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("Running Threads...");
            Thread t1 = new Thread(DoSomeWork); t1.Start(3);
            Thread t2 = new Thread(DoSomeWork); t2.Start(6);
            Thread t3 = new Thread(DoSomeWork); t3.Start(9);
            Thread t4 = new Thread(DoSomeWork); t4.Start(12);
            Thread t5 = new Thread(DoSomeWork); t5.Start(15);
            Thread t6 = new Thread(DoSomeWork); t6.Start(18);
            Thread t7 = new Thread(DoSomeWork); t7.Start(21);
            Thread t8 = new Thread(DoSomeWork); t8.Start(24);
            
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();

            sw.Stop();
            Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds);
        }

        static void RunPool()
        {
            // No *EASY* way to measure
            Console.WriteLine("Running Pool...");

            ThreadPool.QueueUserWorkItem(DoSomeWork, 3);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 6);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 9);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 12);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 15);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 18);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 21);
            ThreadPool.QueueUserWorkItem(DoSomeWork, 24);
        }

        static void RunTasks()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("Running Tasks...");
            Task t1 = Task.Factory.StartNew(DoSomeWork, 3);
            Task t2 = Task.Factory.StartNew(DoSomeWork, 6);
            Task t3 = Task.Factory.StartNew(DoSomeWork, 9);
            Task t4 = Task.Factory.StartNew(DoSomeWork, 12);
            Task t5 = Task.Factory.StartNew(DoSomeWork, 15);
            Task t6 = Task.Factory.StartNew(DoSomeWork, 18);
            Task t7 = Task.Factory.StartNew(DoSomeWork, 21);
            Task t8 = Task.Factory.StartNew(DoSomeWork, 24);
            
            t1.Wait();
            t2.Wait();
            t3.Wait();
            t4.Wait();
            t5.Wait();
            t6.Wait();
            t7.Wait();
            t8.Wait();

            sw.Stop();
            Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds);
        }
    }
}
