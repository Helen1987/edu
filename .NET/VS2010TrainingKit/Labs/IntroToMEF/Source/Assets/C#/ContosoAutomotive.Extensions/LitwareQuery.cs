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
    public class LitwareQuery : CarQueryBase
    {
        public LitwareQuery()
        {
            this.Name = "Litware Limousines";
            this.Description = "Grab a Litware. We can make an absolutely steal off these party favorites.";
            this.ImagePath = "Images/litware.jpg";
        }

        protected override IEnumerable<Car> RunQuery(IEnumerable<Car> cars)
        {
            var results = from c in cars
                          where c.Make == "Litware"
                            && c.Model == "Purus Limo"
                            && c.Price <= 20000
                            && c.Year >= 2000
                            && c.Transmission == Transmission.Automatic
                            && c.Mpg >= 20
                            && c.Mileage <= 30000
                            && c.Interior == InteriorType.Cloth
                          select c;

            return results;
        }
    }
}
