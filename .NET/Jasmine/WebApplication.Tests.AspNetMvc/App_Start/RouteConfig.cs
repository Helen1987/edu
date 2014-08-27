using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication.Tests.AspNetMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("*.html");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Jasmine", action = "Run", id = UrlParameter.Optional }
            );
        }
    }
}