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

namespace ContosoAutomotive.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using ContosoAutomotive.Common;

    public class CohoQuery : CarQueryBase
    {
        public CohoQuery()
        {
            this.Name = "Coho Auto";
            this.Description = "Nothing beats a good price on a Coho. We can't keep these things in stock.";
            this.ImagePath = "Images/coho.jpg";
        }

        protected override IEnumerable<Car> RunQuery(IEnumerable<Car> cars)
        {
            var results = from c in cars
                          where c.Make == "Coho"
                            && (c.Model == "Lorem" || c.Model == "Ipsum")
                            && c.Price <= 25000
                            && c.Year >= 2000
                            && c.Transmission == Transmission.Manual
                            && c.SatelliteRadio == true
                            && c.Mpg >= 20
                            && c.Mileage <= 50000
                            && c.Interior == InteriorType.Suede
                          select c;

            return results;
        }
    }
}
