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
    public class TailspinQuery : CarQueryBase
    {
        public TailspinQuery()
        {
            this.Name = "Tailspin Motorsport";
            this.Description = "Life in the fast lane. You can't live without the best: Tailspin.";
            this.ImagePath = "Images/tailspin.jpg";
        }

        protected override IEnumerable<Car> RunQuery(IEnumerable<Car> cars)
        {
            var results = from c in cars
                          where c.Make == "Tailspin"
                            && c.Model == "Tempor"
                            && c.Price <= 40000
                            && c.Year >= 2005
                            && c.Transmission == Transmission.Automatic
                            && c.SatelliteRadio == true
                            && c.MoonRoof == true
                            && c.Mpg >= 25
                            && c.Mileage <= 10000
                            && c.Interior == InteriorType.Suede
                          select c;

            return results;
        }
    }
}
