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
using System.Diagnostics;
using System.ServiceModel;
using CalculatorService;

namespace RoundingCalculatorService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Multiple)]
    public class RoundingCalculatorService : ICalculatorService
    {
        public double Add(double n1, double n2)
        {
            ShowOp("Add");
            return Math.Round(n1 + n2, 1);
        }

        public double Subtract(double n1, double n2)
        {
            ShowOp("Subtract");
            return Math.Round(n1 - n2, 1);
        }

        public double Multiply(double n1, double n2)
        {
            ShowOp("Multiply");
            return Math.Round(n1 * n2, 1);
        }

        public double Divide(double n1, double n2)
        {
            ShowOp("Divide");
            return Math.Round(n1 / n2, 1);
        }

        private void ShowOp(string operation)
        {
            string msg = string.Format("Rounding Calc: {0}", operation);

            Debug.WriteLine(msg);
            Console.WriteLine(msg);
        }
    }
}
