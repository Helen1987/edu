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
    using System.Collections.Generic;

    public class CarGenerator
    {
        private Random random;
        private List<string> makes;
        private Dictionary<string, List<string>> models;
        private List<string> colors;
        private List<string> interior;
        private List<string> transmission;

        public CarGenerator()
        {
            this.random = new Random();
            this.PopulateLookups();
        }

        public Car Generate()
        {
            var year = random.Next(1990, 2008);
            var makeIndex = random.Next(0, makes.Count);
            var modelIndex = random.Next(0, models[makes[makeIndex]].Count);
            var transmissionIndex = random.Next(0, transmission.Count);
            var exteriorColorIndex = random.Next(0, colors.Count);
            var interiorMaterialIndex = random.Next(0, interior.Count);
            var mileage = random.Next(5000, 95000);
            var mpg = random.Next(10, 40);
            var price = random.Next(15000, 70000);
            var satelliteRadio = random.Next(0, 2);
            var moonRoof = random.Next(0, 2);
            var heatedSeats = random.Next(0, 2);
            var gps = random.Next(0, 2);

            var car = new Car();
            car.Year = year;
            car.Make = makes[makeIndex];
            car.Model = models[makes[makeIndex]][modelIndex];
            car.Transmission = (Transmission)Enum.Parse(typeof(Transmission), transmission[transmissionIndex], true);
            car.Color = colors[exteriorColorIndex];
            car.Interior = (InteriorType)Enum.Parse(typeof(InteriorType), interior[interiorMaterialIndex], true);
            car.Mileage = mileage;
            car.Mpg = mpg;
            car.Price = price;
            car.SatelliteRadio = (satelliteRadio == 0) ? false : true;
            car.MoonRoof = (moonRoof == 0) ? false : true;
            car.HeatedSeats = (heatedSeats == 0) ? false : true;
            car.Gps = (gps == 0) ? false : true;

            return car;
        }

        private void PopulateLookups()
        {
            this.makes = new List<string>() { "Coho", "Wingtip", "Fabrikam", "Litware", "Tailspin", "Woodgrove" };

            this.models = new Dictionary<string, List<string>>()
            {
                { "Coho", new List<string>() { "Lorem","Ipsum","L93","IP123" } },
                { "Wingtip", new List<string>() { "Lacinia","Vitae","Aliqua" } },
                { "Fabrikam", new List<string>() { "Amet 23","Amet 34","Amet 45","Amet 56","Amet 67","Amet 78","Amet 89" } },
                { "Woodgrove", new List<string>() { "Torquent LS","Torquent RS" } },
                { "Litware", new List<string>() { "Purus Limo","Purus Sedan","Dolor Limo","Dolor Sedan" } },
                { "Tailspin", new List<string>() { "Tempor", "Elit", "Elit LS", "Enim RS" } },
            };

            this.colors = new List<string>
            {
                "Black","Blue","Bronze","Burgundy","Charcoal","Crimson","Dark Blue","Dark Gray",
                "Dark Green","Gray","Green","Light Blue","Light Green","Light Silver","Maroon",
                "Purple","Red","Silver","Tan","Teal","White","Yellow"
            };

            this.transmission = new List<string>() { "Manual", "Automatic" };

            this.interior = new List<string>() { "Leather", "Cloth", "Suede" };
        }
    }
}
