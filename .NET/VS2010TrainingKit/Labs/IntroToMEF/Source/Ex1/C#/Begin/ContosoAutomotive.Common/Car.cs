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

namespace ContosoAutomotive.Common
{
    using System;
    using System.Globalization;

    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Transmission Transmission { get; set; }
        public string Color { get; set; }
        public InteriorType Interior { get; set; }
        public int Mileage { get; set; }
        public int Mpg { get; set; }
        public int Price { get; set; }
        public bool SatelliteRadio { get; set; }
        public bool MoonRoof { get; set; }
        public bool HeatedSeats { get; set; }
        public bool Gps { get; set; }

        public void Deserialize(string csv)
        {
            if (string.IsNullOrEmpty(csv))
            {
                throw new ArgumentNullException("csv");
            }

            var dataParts = csv.Split(',');

            this.Year = int.Parse(dataParts[0], CultureInfo.InvariantCulture);
            this.Make = dataParts[1];
            this.Model = dataParts[2];
            this.Transmission = (Transmission)Enum.Parse(typeof(Transmission), dataParts[3], true);
            this.Color = dataParts[4];
            this.Interior = (InteriorType)Enum.Parse(typeof(InteriorType), dataParts[5], true);
            this.Mileage = int.Parse(dataParts[6], CultureInfo.InvariantCulture);
            this.Mpg = int.Parse(dataParts[7], CultureInfo.InvariantCulture);
            this.Price = int.Parse(dataParts[8], CultureInfo.InvariantCulture);
            this.SatelliteRadio = (dataParts[9] == "0") ? false : true;
            this.MoonRoof = (dataParts[10] == "0") ? false : true;
            this.HeatedSeats = (dataParts[11] == "0") ? false : true;
            this.Gps = (dataParts[12] == "0") ? false : true;
        }

        public string Serialize()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                this.Year, this.Make, this.Model, this.Transmission, this.Color, this.Interior, this.Mileage, this.Mpg,
                this.Price, this.SatelliteRadio, this.MoonRoof, this.HeatedSeats, this.Gps);
        }
    }
}
