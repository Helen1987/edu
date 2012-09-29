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

namespace ContosoAutomotive.Extensions.Woodgrove
{
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.Composition;
    using ContosoAutomotive.Common;

    [Export(typeof(ICarQuery))]
    public class WoodgroveQuery : CarQueryBase
    {
        public WoodgroveQuery()
        {
            this.Name = "Woodgrove Cycles";
            this.Description = "Who doesn't love a Woodgrove? The fastest thing on two wheels!";
            this.ImagePath = "Images/woodgrove.jpg";
        }

        protected override IEnumerable<Car> RunQuery(IEnumerable<Car> cars)
        {
            var results = from c in cars
                          where c.Make == "Woodgrove"
                          && c.Price >= 50000
                          && c.Year >= 2000
                          && c.Transmission == Transmission.Manual
                          && c.SatelliteRadio == true
                          && c.MPG >= 20
                          && c.Interior == InteriorType.Suede
                          && c.MoonRoof == false
                          && c.Mileage <= 40000
                          select c;

            return results;
        }
    }
}
