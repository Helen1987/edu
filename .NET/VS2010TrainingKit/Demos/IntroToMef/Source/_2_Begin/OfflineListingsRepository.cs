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
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ContosoRealtor
{
    [Export(typeof(IListingsRepository))]
    public class OfflineListingsRepository : IListingsRepository
    {
        [Import("OfflineListingsPath")]
        string OfflineListingsPath { get; set; }

        [Import(typeof(ILogger))]
        ILogger Logger { get; set; }

        public string Status
        {
            get { return "Getting listings locally"; }
        }

        public IList<Listing> GetAllListings()
        {
            if (File.Exists(OfflineListingsPath))
            {
                Logger.WriteLine("Getting downloaded listings");
                using (TextReader reader = new StreamReader(OfflineListingsPath))
                {
                    var serializer = new XmlSerializer(typeof(List<Listing>));
                    var listings = (List<Listing>)serializer.Deserialize(reader);

                    return listings;
                }
            }
            else
            {
                Logger.WriteLine("No listings available, none have been downloaded");
                return new List<Listing>();
            }
        }
    }
}
