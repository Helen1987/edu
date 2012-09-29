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
using System.Web.Routing;
using Microsoft.Practices.Unity;
using MvcMusicStore.Services;
using MvcMusicStore.Factories;
using MvcMusicStore.Controllers;

namespace MvcMusicStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            
            var container = new UnityContainer();
            container.RegisterType<IStoreService, StoreService>();
            container.RegisterType<IController, StoreController>("Store");

            var factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);

            // You could implement another IMessageService, maybe a dynamic one
            container.RegisterInstance<IMessageService>(new MessageService { 
                Message = "You are welcome to our Web Camps Training Kit!",
                ImageUrl = "/Content/Images/logo-webcamps.png"    
            });
            container.RegisterType<IViewPageActivator, CustomViewPageActivator>(new InjectionConstructor(container));

            IDependencyResolver resolver = DependencyResolver.Current;

            IDependencyResolver newResolver = new UnityDependencyResolver(container, resolver);

            DependencyResolver.SetResolver(newResolver);
        }
    }
}