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

namespace MvcMusicStore.Filters
{
    public class ActionLogFilterProvider : IFilterProvider
    {
        private IList<ControllerAction> actions = new List<ControllerAction>();

        public void Add(string controllername, string actionname)
        {
            actions.Add(new ControllerAction() { ControllerName = controllername, ActionName = actionname });
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            foreach (ControllerAction action in actions)
                if ((action.ControllerName == actionDescriptor.ControllerDescriptor.ControllerName || action.ControllerName == "*")
                    && (action.ActionName == actionDescriptor.ActionName || action.ActionName == "*")) {
                        yield return new Filter(new ActionLogFilterAttribute(), FilterScope.First, null);
                    break;
                }

            yield break;
        }
    }

    internal class ControllerAction
    {
        internal string ControllerName { get; set; }
        internal string ActionName { get; set; }
    }
}