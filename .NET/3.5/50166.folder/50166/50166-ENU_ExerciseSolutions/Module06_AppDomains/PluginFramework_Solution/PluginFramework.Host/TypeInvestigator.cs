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
            AppDomain domain = AppDomain.CreateDomain("TemporaryDomain");
            TypeInvestigator instance = new TypeInvestigator(assembly);
            domain.DoCallBack(instance.GetExportedTypes);
            return instance._types;
        }

        private readonly string _assembly;
        private string[] _types;

        private TypeInvestigator(string assembly)
        {
            _assembly = assembly;
        }

        private void GetExportedTypes()
        {
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += new ResolveEventHandler(CurrentDomain_ReflectionOnlyAssemblyResolve);

            Assembly assembly = Assembly.ReflectionOnlyLoadFrom(_assembly);
            _types = (from type in assembly.GetExportedTypes()
                      where type.BaseType.AssemblyQualifiedName == typeof(PluginBase).AssemblyQualifiedName
                      select type.FullName).ToArray();
        }

        Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
}
