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
using System.Text;

namespace ContosoAutomotive
{
    public enum Transmission
    {
        Automatic,
        Manual
    }

    public enum InteriorType
    {
        Cloth,
        Leather,
        Suede
    }

    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Transmission Transmission { get; set; }
        public string Color { get; set; }
        public InteriorType Interior { get; set; }
        public int Mileage { get; set; }
        public int MPG { get; set; }
        public int Price { get; set; }
        public bool SatelliteRadio { get; set; }
        public bool MoonRoof { get; set; }
        public bool HeatedSeats { get; set; }
        public bool GPS { get; set; }

        public void Load(string csv)
        {
            var dataParts = csv.Split(',');

            Year = int.Parse(dataParts[0]);
            Make = dataParts[1];
            Model = dataParts[2];
            Transmission = (Transmission)Enum.Parse(typeof(Transmission), dataParts[3]);
            Color = dataParts[4];
            Interior = (InteriorType)Enum.Parse(typeof(InteriorType), dataParts[5]);
            Mileage = int.Parse(dataParts[6]);
            MPG = int.Parse(dataParts[7]);
            Price = int.Parse(dataParts[8]);
            SatelliteRadio = (dataParts[9] == "0") ? false : true;
            MoonRoof = (dataParts[10] == "0") ? false : true;
            HeatedSeats = (dataParts[11] == "0") ? false : true;
            GPS = (dataParts[12] == "0") ? false : true;
        }
    }
}
