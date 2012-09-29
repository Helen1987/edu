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
    using System.ComponentModel.Composition;
    using System.Linq;
    using ContosoAutomotive.Common;

    [Export(typeof(ICarQuery))]
    public class WingtipQuery : CarQueryBase
    {
        public WingtipQuery()
        {
            this.Name = "Wingtip Automobiles";
            this.Description = "Ah, the Wingtip. The joy of millionaires. But can we find a low mileage one?";
            this.ImagePath = "Images/wingtip.jpg";
        }

        protected override IEnumerable<Car> RunQuery(IEnumerable<Car> cars)
        {
            var results = from c in cars
                          where c.Make == "Wingtip"
                            && c.Price >= 60000
                            && c.Year >= 2000
                            && c.Transmission == Transmission.Automatic
                            && c.SatelliteRadio == true
                            && c.MPG >= 15
                            && c.Mileage <= 60000
                            && c.Interior == InteriorType.Leather
                          select c;

            return results;
        }
    }
}
