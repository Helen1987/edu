using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /*config.Routes.MapHttpRoute(
                name: "PostByDate",
                routeTemplate: "api/Posts/{year}/{month}/{day}",
                defaults: new
                {
                    controller = "Posts",
                    month = RouteParameter.Optional,
                    day = RouteParameter.Optional
                },
                constraints: new
                {
                    month = @"\d{0,2}",
                    day = @"\d{0,2}"
                }
            );*/

            config.Routes.MapHttpRoute(
                name: "Archive",
                routeTemplate: "api/posts/archive/{year}/{month}/{day}",
                defaults: new {
                    controller = "Posts",
                    month = RouteParameter.Optional,
                    day = RouteParameter.Optional },
                constraints: new { month = @"\d{0,2}", day = @"\d{0,2}" });

            config.Routes.MapHttpRoute(
                name: "PostsCustomAction",
                routeTemplate: "api/{controller}/{action}/{id}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
