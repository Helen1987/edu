using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.MobileControls;
using MvcAjaxForms.Models;

namespace MvcAjaxForms.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Contacts()
        {
            ViewData["Contacts"] = DataManager.Load();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult EditContact(int id)
        {
            ViewData.Model = DataManager.Load().SingleOrDefault(c => c.Id == id);
            return View();
        }


        public ActionResult NewData()
        {
            return Content("Форма обновлена");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditContact(int id, Contact obj)
        {
            if (obj.FirstName.Length == 0) ModelState.AddModelError("FirstName", "Укажите имя.");
            if (obj.LastName.Length == 0) ModelState.AddModelError("LastName", "Укажите фамилию.");
            if (obj.Company.Length == 0) ModelState.AddModelError("Company", "Укажите компанию.");

            if (ModelState.IsValid)
            {
                List<Contact> lst = DataManager.Load();
                Contact contact = lst.SingleOrDefault(c => c.Id == id);
                contact.FirstName = obj.FirstName;
                contact.LastName = obj.LastName;
                contact.Company = obj.Company;
                DataManager.Save(lst);


                if (Request.IsAjaxRequest())
                {
                    return Json(contact);
                }

                return RedirectToAction("Contacts");
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("EditForm");
            }

            return View();
        }

    }
}
