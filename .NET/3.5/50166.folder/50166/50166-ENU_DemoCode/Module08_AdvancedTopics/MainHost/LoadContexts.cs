using System;
using System.Reflection;
using Plugin;

namespace MainHost
{
    /// <summary>
    /// This demo highlights the problem of assembly loading context.  The rules
    /// of assembly binding in the CLR are very complicated, and it's possible
    /// for the same assembly to be loaded into the default load context and into
    /// the load-from context.  Types from the two assemblies are considered
    /// incompatible even they "are the same type".
    /// 
    /// This phenomenon is explained in greater detail in the slides and in the following
    /// blog post:
    ///     http://blogs.microsoft.co.il/blogs/sasha/archive/2007/03/06/Assembly-Load-Contexts-Subtleties.aspx
    /// </summary>
    class LoadContexts
    {
        static void PrintLoadedAssemblies()
        {
            Console.WriteLine("------------------");
            Array.ForEach(AppDomain.CurrentDomain.GetAssemblies(),
                delegate(Assembly a) { Console.WriteLine(a.Location); });
        }

        static void Main(string[] args)
        {
            PrintLoadedAssemblies();

            //Uncomment the following line to see the problem go away, because
            //the JIT forces a pre-load of the MyPlugin type before it is explicitly
            //loaded by the Assembly.LoadFrom method call.  If the assembly is 
            //already loaded into the default load context, it will be not be loaded
            //again into the load-from context.
            //
            //MyPlugin myPlugin = null;

            Assembly plugin = Assembly.LoadFrom(@"..\..\..\Plugin\bin\Debug\Plugin.dll");

            PrintLoadedAssemblies();

            Method(plugin);

            PrintLoadedAssemblies();
        }

        static void Method(Assembly plugin)
        {
            //This cast fails because the two MyPlugin types are incompatible.
            //The MyPlugin type which appears in the code is resolved by the JIT
            //to the load context, but the Plugin.MyPlugin type which is created
            //using reflection (Assembly.CreateInstance) is resolved to the
            //load-from context.  The exception message (as of .NET 3.5) discloses
            //the problem right away.
            MyPlugin myPlugin2 = (MyPlugin)plugin.CreateInstance("Plugin.MyPlugin");
        }
    }
}
