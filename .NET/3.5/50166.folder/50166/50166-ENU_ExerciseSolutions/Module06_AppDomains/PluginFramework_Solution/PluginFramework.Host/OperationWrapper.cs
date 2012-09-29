using System;
using PluginFramework.PluginInterface;

namespace PluginFramework.Host
{
    /// <summary>
    /// Represents an operation.  Conceals the creation of an application domain
    /// to host the plugin object and delegates the operation to the plugin hosted
    /// in a separate domain.
    /// </summary>
    class OperationWrapper
    {
        private readonly AppDomain _domain;
        private readonly IPlugin _plugin;

        public string Name { get { return _plugin.Name; } }

        public OperationWrapper(string assembly, string type)
        {
            _domain = AppDomain.CreateDomain("OperationWrapper_+ " + type);
            _plugin = (IPlugin)_domain.CreateInstanceFromAndUnwrap(assembly, type);
        }

        public double Operation(double[] input)
        {
            return _plugin.Operation(input);
        }
    }
}
