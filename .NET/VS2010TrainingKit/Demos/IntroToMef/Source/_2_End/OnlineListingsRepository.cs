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
using System.Linq;
using System.Text;

namespace ContosoRealtor
{
    [Export(typeof(IListingsRepository))]
    [ExportMetadata("NetworkStatus", "Online")]
    public class OnlineListingsRepository : IListingsRepository
    {
        IList<Listing> listings;

        public OnlineListingsRepository()
        {
            listings = new List<Listing>() 
            { 
                new Listing() { ListingId = 1, Price = 295000, Address = "1242 NE 129th St", City = "Kirkland", State = "WA", Zip = 98034 },
                new Listing() { ListingId = 2, Price = 360500, Address = "312 S Baker Ave", City = "Redmond", State = "WA", Zip = 98032 },
                new Listing() { ListingId = 3, Price = 525000, Address = "99120 W 12th St", City = "Redmond", State = "WA", Zip = 98032 }
            };

            // One could just as easily grab the listings from ADO.NET Data Services
            // like so (don't do it here so the demo is easy to repro)
            //data = new ContosoRealEstateContext(new Uri(ListingServiceUri));
            //listings = data.Listings.ToList();
        }

        public string Status
        {
            get { return "Getting listings from the web"; }
        }

        public IList<Listing> GetAllListings()
        {
            return listings;
        }
    }
}
