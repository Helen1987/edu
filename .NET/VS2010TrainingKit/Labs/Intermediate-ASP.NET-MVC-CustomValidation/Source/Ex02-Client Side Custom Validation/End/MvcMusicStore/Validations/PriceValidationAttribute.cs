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
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Validations
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PriceValidationAttribute : ValidationAttribute, IClientValidatable
    {
        private decimal minPrice = 0.01M;
        private decimal maxPrice = 100.00M;

        public PriceValidationAttribute(): base("The price is not in a valid range")
        {
        }

        public override bool IsValid(object value)
        {
            decimal price = (decimal)value;
            if (price < this.minPrice || price > this.maxPrice)
                return false;
            return true;
        }

        // Client-Side validation
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientPriceRangeValidationRule("The price is not in a valid range.", this.minPrice, this.maxPrice);
            
            yield return rule;
        }
        
    }
}
