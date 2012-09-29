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

namespace InsurancePolicy
{
    public class AutoInsurance
    {
        public static readonly int MAXIMUM_VEHICLE_AGE = 10;

        // (THIS IS NOT A REAL FORMULA)
        public static decimal CalculatePremium(decimal bookValue, int manufacturedYear, decimal bodyStyleFactor, decimal brakeTypeFactor, decimal safetyEquipmentFactor, decimal antiTheftDeviceFactor)
        {
            var ageFactor = (manufacturedYear - DateTime.Today.Year + MAXIMUM_VEHICLE_AGE) * 2000 / bookValue;
            decimal coefficient = (bodyStyleFactor + brakeTypeFactor + safetyEquipmentFactor + antiTheftDeviceFactor + ageFactor) / 100;
            decimal premium = bookValue * coefficient;

            return premium;
        }
    }
}
