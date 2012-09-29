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

namespace Two.IronPythonInterop
{
    using System;
    using System.Linq;
    using IronPython.Hosting;
    using Microsoft.Scripting.Hosting;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading random.py...");

            ScriptRuntime py = Python.CreateRuntime();
            dynamic random = py.UseFile("random.py");

            Console.WriteLine("random.py loaded!");

            var items = Enumerable.Range(1, 7).ToArray();
            for (int i = 0; i < 10; i++)
            {
                random.shuffle(items);
                foreach (int item in items)
                {
                    Console.Write("{0} ", item);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
