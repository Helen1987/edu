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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace WCF4Configuration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EchoService" in code, svc and config file together.
    public class EchoService : IEchoService
    {
        public string Echo(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

            return string.Format(CultureInfo.InvariantCulture, "Echo: {0}", message);
        }
    }
}
