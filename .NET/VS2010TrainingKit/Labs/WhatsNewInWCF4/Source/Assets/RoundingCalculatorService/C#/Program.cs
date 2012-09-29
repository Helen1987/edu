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
using System.Net;
using System.ServiceModel;

namespace RoundingCalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rounding Calculator Service";
            Console.WriteLine("Rounding Calculator Service Console Host");
            string hostName = Dns.GetHostName();

            using (ServiceHost host = HostRoundingCalculatorEndpoint(hostName))
            {
                Console.WriteLine("Press <Enter> to exit");
                Console.ReadLine();
                host.Close();
            }
        }

        private static ServiceHost HostRoundingCalculatorEndpoint(string hostName)
        {
            ServiceHost calculatorHost = new
                ServiceHost(new RoundingCalculatorService());

            calculatorHost.Open();

            Console.WriteLine("Rounding Service listening at {0}", calculatorHost.Description.Endpoints[0].Address.ToString());

            return calculatorHost;
        }
    }
}
