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
using System.Web.Mvc;
using FabrikamInsurance.Models;
using InsurancePolicy;

namespace FabrikamInsurance.Controllers
{
    [HandleError]
    public class QuoteController : Controller
    {
        private IAutomobileDataRepository repository;

        public QuoteController()
            : this(new AutomobileDataRepository())
        {
        }

        public QuoteController(IAutomobileDataRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult About()
        {
            System.Diagnostics.Trace.TraceInformation("About called...");
            return View();
        }

        public ActionResult Calculator()
        {
            System.Diagnostics.Trace.TraceInformation("Calculator called...");
            QuoteViewModel model = new QuoteViewModel();
            PopulateViewModel(model, null);
            return View(model);
        }

        [HttpPost]
        public ActionResult Calculator(QuoteViewModel model)
        {            
            PopulateViewModel(model, model.MakeId);

            if (ModelState.IsValid)
            {
                decimal bookValue = this.repository.GetBookValue(model.MakeId, model.ModelId);
                decimal bodyStyleFactor = model.BodyStyles.Where(item => item.Id == model.BodyStyleId).FirstOrDefault().Value;
                decimal brakeTypeFactor = model.BrakeTypes.Where(item => item.Id == model.BrakeTypeId).FirstOrDefault().Value;
                decimal safetyEquipmentFactor = model.SafetyEquipment.Where(item => item.Id == model.SafetyEquipmentId).FirstOrDefault().Value;
                decimal antiTheftDeviceFactor = model.AntiTheftDevices.Where(item => item.Id == model.AntiTheftDeviceId).FirstOrDefault().Value;
                decimal premium = AutoInsurance.CalculatePremium(bookValue, model.ManufacturedYear, bodyStyleFactor, brakeTypeFactor, safetyEquipmentFactor, antiTheftDeviceFactor);
                model.MonthlyPremium = premium / 12;
                model.YearlyPremium = premium;
            }

            return View(model);
        }

        private void PopulateViewModel(QuoteViewModel model, string makeId)
        {
            model.Makes = this.repository.GetMakes();
            model.Models = this.repository.GetModels(makeId);
            model.BodyStyles = this.repository.GetBodyStyles();
            model.BrakeTypes = this.repository.GetBrakeTypes();
            model.SafetyEquipment = this.repository.GetSafetyEquipment();
            model.AntiTheftDevices = this.repository.GetAntiTheftDevices();
            model.YearList = Enumerable.Range(DateTime.Today.Year - AutoInsurance.MAXIMUM_VEHICLE_AGE + 1, AutoInsurance.MAXIMUM_VEHICLE_AGE);            
        }

        [HttpPost]
        public ActionResult GetModels(string id)
        {            
            return Json(this.repository.GetModels(id));
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            System.Diagnostics.Trace.TraceError(filterContext.Exception.Message);
        }
    }
}
