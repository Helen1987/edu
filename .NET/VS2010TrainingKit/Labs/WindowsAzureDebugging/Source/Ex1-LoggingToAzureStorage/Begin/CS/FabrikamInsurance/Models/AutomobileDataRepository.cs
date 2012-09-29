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
using System.Web;
using System.Xml.Linq;

namespace FabrikamInsurance.Models
{
    public class AutomobileDataRepository 
        : IAutomobileDataRepository
    {
        private static XElement automobileData;

        static AutomobileDataRepository()
        {
            AutomobileDataRepository.automobileData = 
                XElement.Load(HttpContext.Current.Server.MapPath("~/App_Data/AutomobileData.xml"));
        }

        public IEnumerable<KeyValuePair<string, string>> GetMakes()
        {
            return from make in AutomobileDataRepository.automobileData.Element("automobiles").Elements("make")
                   orderby make.Attribute("name").Value
                   select new KeyValuePair<string, string>(make.Attribute("id").Value, make.Attribute("name").Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetModels(string makeId)
        {
            return from make in AutomobileDataRepository.automobileData.Element("automobiles").Elements("make")
                   from model in make.Elements("model")
                   where make.Attribute("id").Value == makeId
                   orderby model.Value
                   select new KeyValuePair<string, string>(model.Attribute("id").Value, model.Value);
        }

        public IEnumerable<Factor> GetBodyStyles()
        {
            return GetOptionList("bodystyles");
        }

        public IEnumerable<Factor> GetBrakeTypes()
        {
            return GetOptionList("braketypes");
        }

        public IEnumerable<Factor> GetSafetyEquipment()
        {
            return GetOptionList("safetyequipment");
        }

        public IEnumerable<Factor> GetAntiTheftDevices()
        {            
            return GetOptionList("antitheftdevices");
        }
        
        public decimal GetBookValue(string makeId, string modelId)
        {
            var bookValue = (from make in AutomobileDataRepository.automobileData.Element("automobiles").Elements("make")
                            from model in make.Elements("model")
                            where make.Attribute("id").Value == makeId && model.Attribute("id").Value == modelId
                            select model.Attribute("bookValue").Value).FirstOrDefault();

            return bookValue != null ? Convert.ToDecimal(bookValue) : -1;
        }

        private IEnumerable<Factor> GetOptionList(string name)
        {
            return from item in AutomobileDataRepository.automobileData.Element(name).Elements("option")
                   orderby item.Attribute("id").Value
                   select new Factor 
                   {
                       Id = item.Attribute("id").Value,
                       Name = item.Value,
                       Value = Convert.ToDecimal(item.Attribute("factor").Value)
                   };
        }
    }
}