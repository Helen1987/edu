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

    public class FabrikamQuery : CarQueryBase
    {
        public FabrikamQuery()
        {
            this.Name = "Fabrikam Motor Company";
            this.Description = "Low Mileage, Low Price FMCs that have wonderful resell value.";
            this.ImagePath = "Images/fabrikam.jpg";
        }

        protected override IEnumerable<Car> RunQuery(IEnumerable<Car> cars)
        {
            var results = from c in cars
                          where c.Make == "Fabrikam"
                            && (c.Model == "Amet 23" || c.Model == "Amet 34" || c.Model == "Amet 45")
                            && c.Price <= 40000
                            && c.Year >= 1995
                            && c.Transmission == Transmission.Manual
                            && c.SatelliteRadio == true
                            && c.MoonRoof == true
                            && c.Mpg >= 25
                            && c.Mileage <= 60000
                            && c.Interior == InteriorType.Leather
                          select c;

            return results;
        }
    }
}
