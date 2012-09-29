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
using System.Diagnostics;
using System.Threading;

namespace PLINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 1000);

            // Remove AsParallel() Method in PLINQ query to see the difference in speed
            IEnumerable<int> results = from n in numbers.AsParallel()
                                       where IsDivisibleByFive(n)
                                       select n;

            Stopwatch sw = Stopwatch.StartNew();
            IList<int> resultsList = results.ToList();
            Console.WriteLine("{0} items", resultsList.Count());
            sw.Stop();

            Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds);

            Console.WriteLine("\nFinished...");
            Console.ReadKey(true);
        }

        static bool IsDivisibleByFive(int i)
        {
            Thread.SpinWait(2000000);

            return i % 5 == 0;
        }
    }
}
