using System;

namespace PluginFramework.Host
{
    /// <summary>
    /// Assists in retrieving types derived from the PluginBase class from
    /// an assembly without loading the assembly to the calling application
    /// domain.
    /// </summary>
    class TypeInvestigator : MarshalByRefObject
    {
        public static string[] GetExportedTypesFromAssembly(string assembly)
        {
            //TODO: Load the specified assembly in a separate application domain
            //(make sure it does not "leak" into the calling domain) and enumerate
            //all exported types in that assembly which inherit the PluginBase
            //class.  It is advised that you load the assembly in the target domain
            //using reflection-only load (Assembly.ReflectionOnlyLoadFrom).
            //You may use the AppDomain.DoCallback method or any other mechanism
            //for invoking code within the separate application domain in order
            //to obtain the list of exported types.

            throw new NotImplementedException();
        }
    }
}
