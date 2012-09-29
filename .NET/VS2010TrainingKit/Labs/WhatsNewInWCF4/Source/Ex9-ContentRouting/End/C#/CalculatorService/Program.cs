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
using System.ServiceModel;
using CalculatorService;
using System.Net;

namespace CalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculator Service";
            Console.WriteLine("Calculator Service Console Host");
            string hostName = Dns.GetHostName();

            using (ServiceHost host = HostCalculatorEndpoint(hostName))
            {
                Console.WriteLine("Press <Enter> to exit");
                Console.ReadLine();
                host.Close();
            }
        }

        private static ServiceHost HostCalculatorEndpoint(string hostName)
        {
            ServiceHost calculatorHost = new
                ServiceHost(new CalculatorService());

            calculatorHost.Open();
            
            Console.WriteLine("Calculator Service listening at {0}", calculatorHost.Description.Endpoints[0].Address.ToString());

            return calculatorHost;
        }
    }
}
