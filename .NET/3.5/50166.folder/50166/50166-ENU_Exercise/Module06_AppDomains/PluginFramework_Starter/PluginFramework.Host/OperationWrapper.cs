using System;

namespace PluginFramework.Host
{
    /// <summary>
    /// Represents an operation.  Conceals the creation of an application domain
    /// to host the plugin object and delegates the operation to the plugin hosted
    /// in a separate domain.
    /// </summary>
    class OperationWrapper
    {
        public string Name { get { throw new NotImplementedException(); } }

        public OperationWrapper(string assembly, string type)
        {
            //TODO: Create an instance of the plugin specified by the assembly
            //and type parameters in a separate application domain.
        }

        public double Operation(double[] input)
        {
            throw new NotImplementedException();

            //TODO: Delegate the call to the instance of the plugin created
            //in the constructor of this class.
        }
    }
}
