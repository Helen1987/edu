using System;
using System.Linq;
using System.Reflection;
using PluginFramework.PluginInterface;

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
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            AppDomain domain = AppDomain.CreateDomain("TemporaryDomain");
            var instance = (TypeInvestigator)domain.CreateInstanceAndUnwrap(thisAssembly.FullName, typeof(TypeInvestigator).FullName);
            //TypeInvestigator instance = new TypeInvestigator(assembly);
            var result = instance.GetExportedTypes(assembly);
            AppDomain.Unload(domain);
            return result;          
        }

        //private readonly string _assembly;
        private string[] _types;

        //private TypeInvestigator(string assembly)
        //{
        //    _assembly = assembly;
        //}

        private string[] GetExportedTypes(string _assembly)
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName); 
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);

            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(_assembly);
            return (from type in assembly.GetExportedTypes()
                      where type.BaseType.AssemblyQualifiedName == typeof(PluginBase).AssemblyQualifiedName
                      select type.FullName).ToArray();
        }

        Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
}
