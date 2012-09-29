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

namespace CountdownEventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = Enumerable.Range(1, 20);

            using (var countdown = new CountdownEvent(1))
            {
                foreach (var customer in customers)
                {
                    int currentCustomer = customer;

                    countdown.AddCount();
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        BuySomeStuff(currentCustomer);
                        countdown.Signal();
                    });
                }

                countdown.Signal();
                countdown.Wait();
            }

            Console.WriteLine("All Customers finished shopping...");
            Console.ReadKey();
        }

        static void BuySomeStuff(int customer)
        {
            // Fake work
            Thread.SpinWait(20000000);

            Console.WriteLine("Customer {0} finished", customer);
        }
    }
}
