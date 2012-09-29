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
using System.Threading;

namespace BarrierDemo
{
    class Program
    {
        static Barrier sync;
        static CancellationToken token;

        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();
            token = source.Token;
            sync = new Barrier(3);

            var charlie = new Thread(() => DriveToBoston("Charlie", TimeSpan.FromSeconds(1))); charlie.Start();
            var mac = new Thread(() => DriveToBoston("Mac", TimeSpan.FromSeconds(2))); mac.Start();
            var dennis = new Thread(() => DriveToBoston("Dennis", TimeSpan.FromSeconds(3))); dennis.Start();

            //source.Cancel();

            charlie.Join();
            mac.Join();
            dennis.Join();

            Console.ReadKey();
        }

        static void DriveToBoston(string name, TimeSpan timeToGasStation)
        {
            try
            {
                Console.WriteLine("[{0}] Leaving House", name);

                // Perform some work
                Thread.Sleep(timeToGasStation);
                Console.WriteLine("[{0}] Arrived at Gas Station", name);

                // Need to sync here
                sync.SignalAndWait(token);

                // Perform some more work
                Console.WriteLine("[{0}] Leaving for Boston", name);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("[{0}] Caravan was cancelled! Going home!", name);
            }
        }
    }
}
