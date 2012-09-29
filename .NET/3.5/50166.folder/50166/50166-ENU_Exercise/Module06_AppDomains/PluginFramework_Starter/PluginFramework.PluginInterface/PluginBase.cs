using System;

namespace PluginFramework.PluginInterface
{
    /// <summary>
    /// The base for all plugins, derives from MarshalByRefObject to ensure
    /// that the plugins are marshaled by reference and implements the Name
    /// property of the IPlugin interface by querying the [Plugin] attribute
    /// placed on the actual type at runtime.
    /// 
    /// Inheriting types must still implement the Operation method.
    /// </summary>
    public abstract class PluginBase : MarshalByRefObject, IPlugin
    {
        public abstract double Operation(double[] input);

        public string Name
        {
            get
            {
                PluginAttribute[] attrs = (PluginAttribute[])this.GetType().GetCustomAttributes(typeof(PluginAttribute), false);
                return attrs[0].Name;
            }
        }
    }
}
