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
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Net.NetworkInformation;
using System.Windows.Threading;

namespace ContosoRealtor
{
    public class NetworkAwareCatalog : ComposablePartCatalog,  INotifyComposablePartCatalogChanged
    {
        private string _networkStatus;
        private ComposablePartCatalog _filteredCatalog;

        public event EventHandler<ComposablePartCatalogChangeEventArgs> Changed;
        public event EventHandler<ComposablePartCatalogChangeEventArgs> Changing;

        public NetworkAwareCatalog(ComposablePartCatalog filteredCatalog)
        {
            _networkStatus = (NetworkInterface.GetIsNetworkAvailable()) ? "Online" : "Offline";
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(NetworkAvailabilityChanged);

            _filteredCatalog = filteredCatalog;
        }

        public override IEnumerable<Tuple<ComposablePartDefinition, ExportDefinition>> GetExports(ImportDefinition definition)
        {
            var exports = base.GetExports(definition);
            return exports;
        }

        public override IQueryable<ComposablePartDefinition> Parts
        {
            get
            {
                return _filteredCatalog.Parts.Where(cpd => NetworkStatusMatches(cpd, _networkStatus) || !NetworkStatusAware(cpd));
            }
        }

        private void NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            // We invoke on the dispatcher because we are needing to recompose UI.
            // If we don't do this, an exception will be thrown as the composition isn't
            // guaranteed to happen on the necesary UI thread.
            Dispatcher.CurrentDispatcher.Invoke(new Action(() =>
            {
                var oldStatus = _networkStatus;
                var newStatus = (e.IsAvailable) ? "Online" : "Offline";

                var added = MatchingParts(newStatus);
                var removed = NonMatchingParts(newStatus);

                using (var atomic = new AtomicComposition())
                {
                    atomic.AddCompleteAction(() => _networkStatus = newStatus);
                    if (Changing != null)
                    {
                        Changing(this, new ComposablePartCatalogChangeEventArgs(added, removed, atomic));
                    }
                    atomic.Complete();
                }

                if (Changed != null)
                {
                    Changed(this, new ComposablePartCatalogChangeEventArgs(added, removed, null));
                }
            }));
        }

        private IEnumerable<ComposablePartDefinition> MatchingParts(string networkStatus)
        {
            return _filteredCatalog.Parts.Where(cpd => NetworkStatusMatches(cpd, networkStatus));
        }

        private IEnumerable<ComposablePartDefinition> NonMatchingParts(string networkStatus)
        {
            return _filteredCatalog.Parts.Where(cpd => !NetworkStatusMatches(cpd, networkStatus) && NetworkStatusAware(cpd));
        }

        private bool NetworkStatusMatches(ComposablePartDefinition cpd, string networkStatus)
        {
            return NetworkStatusAware(cpd) && cpd.Metadata["NetworkStatus"].Equals(networkStatus);
        }

        private bool NetworkStatusAware(ComposablePartDefinition cpd)
        {
            return cpd.Metadata.ContainsKey("NetworkStatus");
        }
    }
}
