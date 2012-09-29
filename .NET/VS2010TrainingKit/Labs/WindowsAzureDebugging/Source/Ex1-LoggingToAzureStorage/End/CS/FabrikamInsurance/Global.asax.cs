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
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace FabrikamInsurance
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Quote", action = "Calculator", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter(RoleEnvironment.GetConfigurationSettingValue(configName));
            });

            ConfigureTraceListener();

            RoleEnvironment.Changed += RoleEnvironmentChanged;

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error()
        {
            var lastError = Server.GetLastError();
            System.Diagnostics.Trace.TraceError(lastError.Message);
        }

        private static void ConfigureTraceListener()
        {
            bool enableTraceListener = false;
            string enableTraceListenerSetting = RoleEnvironment.GetConfigurationSettingValue("EnableTableStorageTraceListener");
            if (bool.TryParse(enableTraceListenerSetting, out enableTraceListener))
            {
                if (enableTraceListener)
                {
                    AzureDiagnostics.TableStorageTraceListener listener =
                        new AzureDiagnostics.TableStorageTraceListener("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString")
                        {
                            Name = "TableStorageTraceListener"
                        };
                    System.Diagnostics.Trace.Listeners.Add(listener);
                    System.Diagnostics.Trace.AutoFlush = true;
                }
                else
                {
                    System.Diagnostics.Trace.Listeners.Remove("TableStorageTraceListener");
                }
            }
        }

        private void RoleEnvironmentChanged(object sender, RoleEnvironmentChangedEventArgs e)
        {
            // configure trace listener for any changes to EnableTableStorageTraceListener 
            if (e.Changes.OfType<RoleEnvironmentConfigurationSettingChange>().Any(change => change.ConfigurationSettingName == "EnableTableStorageTraceListener"))
            {
                ConfigureTraceListener();
            }
        }
    }
}