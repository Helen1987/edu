using System;
using System.Web.Mvc;

namespace WebApplication.Tests.AspNetMvc.Controllers
{
    public class JasmineController : Controller
    {
        public ActionResult Run()
        {
            return new RedirectResult("/spec_runner.html");
        }
    }
}
