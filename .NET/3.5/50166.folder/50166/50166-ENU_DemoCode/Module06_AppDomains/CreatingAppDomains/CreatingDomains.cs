using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace CreatingAppDomains
{
    /// <summary>
    /// This demo shows how application domains are created and unloaded,
    /// and how code can be executed within the boundaries of a different
    /// application domain.  It demonstrates the CreateDomain and Unload
    /// static methods of the AppDomain class, as well as the use of an
    /// AppDomainInitializer delegate and the ExecuteAssembly, CreateInstanceAndUnwrap
    /// and DoCallback instance methods.
    /// </summary>
    class CreatingDomains
    {
        static void Main(string[] args)
        {
            //Used when this Main method is invoked from another application
            //domain and not when the application is executed directly.
            if (args.Length > 0 && args[0] == "fromDomain")
            {
                Console.WriteLine("My domain name: " + AppDomain.CurrentDomain.FriendlyName);
                return;
            }

            UsingAppDomainInitializer();
            UsingExecuteAssembly();
            UsingDoCallback();
            UsingCreateInstance();
            UsingCreateInstanceFails();
        }

        /// <summary>
        /// Demonstrates how an application domain is created and how
        /// its properties can be queried and displayed.  Also demonstrates
        /// how to retrieve the assemblies loaded into an application domain
        /// and how to unload the application domain.  Note that after
        /// unloading an application domain any attempt to access it will
        /// result in an AppDomainUnloadedException exception.
        /// </summary>
        private static void CreatingAndUnloading()
        {
            AppDomain domain =
                AppDomain.CreateDomain("MyFirstDomain");
            Console.WriteLine("Base directory: " +
                domain.BaseDirectory);
            Console.WriteLine("Id: " + domain.Id);
            Console.WriteLine("Configuration file: " +
                domain.SetupInformation.ConfigurationFile);

            Array.ForEach(
                domain.GetAssemblies(), Console.WriteLine);
            //Output:
            //mscorlib, Version=2.0.0.0, Culture=neutral,
            //PublicKeyToken=b77a5c561934e089

            AppDomain.Unload(domain);
            domain.GetAssemblies();
            //Output:
            //Unhandled Exception:
            //System.AppDomainUnloadedException:
            //Attempted to access an unloaded AppDomain.
            //  at System.AppDomain.GetAssemblies()
        }

        /// <summary>
        /// Demonstrates how the AppDomainInitializer delegate can be used
        /// to execute bootstrapping code within an application domain.
        /// The delegate is passed along with the AppDomainSetup object when
        /// the application domain is created, and is invoked as part of
        /// the application domain's initialization process.  Parameters can
        /// be passed to the initialization delegate as an array of strings.
        /// </summary>
        private static void UsingAppDomainInitializer()
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.AppDomainInitializer = OnAppDomainInitialization;
            setup.AppDomainInitializerArguments = new string[] { "Hello from the primary domain!" };
            AppDomain domain = AppDomain.CreateDomain("AnotherDomain", AppDomain.CurrentDomain.Evidence, setup);
            AppDomain.Unload(domain);
        }

        /// <summary>
        /// This method is invoked within the second application domain.
        /// </summary>
        private static void OnAppDomainInitialization(string[] args)
        {
            Console.WriteLine("Initialization arguments: " + String.Join(" ", args));
            Console.WriteLine("Domain name: " + AppDomain.CurrentDomain.FriendlyName);
            Array.ForEach(AppDomain.CurrentDomain.GetAssemblies(), Console.WriteLine);
        }

        /// <summary>
        /// This method demonstrates how the ExecuteAssembly instance method
        /// can be used to execute an arbitrary assembly within the boundaries of
        /// another application domain.  The assembly's location and security
        /// information (evidence) is passed to the method, along with any parameters
        /// that are redirected to the assembly's entry point (Main method).
        /// The ExecuteAssembly method executes synchronously and returns only
        /// when the assembly's entry point has completed execution.
        /// </summary>
        private static void UsingExecuteAssembly()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            AppDomain domain = AppDomain.CreateDomain("ExecuteDomain");
            domain.ExecuteAssembly(thisAssembly.Location, thisAssembly.Evidence, new string[] { "fromDomain" });
            AppDomain.Unload(domain);
        }

        /// <summary>
        /// This method demonstrates how the DoCallback instance method can be used to execute
        /// an arbitrary delegate (with no parameters and a void return value) within another
        /// application domain.  Using an anonymous method with this method is discouraged because
        /// it's impossible to guarantee that if the anonymous method is converted to a class by
        /// the C# compiler, that this class will be marked as serializable.
        /// </summary>
        private static void UsingDoCallback()
        {
            AppDomain domain = AppDomain.CreateDomain("CallbackDomain");
            domain.DoCallBack(TheCrossDomainCallback);
            AppDomain.Unload(domain);
        }

        /// <summary>
        /// This is the callback method which is executed in the target application domain.
        /// Note that because it has no parameters and a void return value it cannot be used
        /// to communicate information into and outside from the application domain.  If this
        /// is desired, then the callback should be placed inside a class (which is either
        /// serializable or marshal-by-reference) and act as an instance method by modifying
        /// the data on the class for output purposes and reading the data on the class for
        /// input purposes.
        /// </summary>
        private static void TheCrossDomainCallback()
        {
            Console.WriteLine("Callback executes in domain: " + AppDomain.CurrentDomain.FriendlyName);
        }

        /// <summary>
        /// This method demonstrates how the CreateInstanceAndUnwrap method can be used
        /// to create an instance of a type within another application domain.  The type
        /// created in this example is System.Int32 (a simple 'int').  Note that even after
        /// the application domain is unloaded, the integer value is still usable, indicating
        /// that it was copied to the calling domain.
        /// </summary>
        private static void UsingCreateInstance()
        {
            AppDomain domain = AppDomain.CreateDomain("InstanceDomain");
            int intFromOtherDomain = (int)domain.CreateInstanceAndUnwrap(typeof(Int32).Assembly.FullName, typeof(Int32).FullName);
            AppDomain.Unload(domain);

            //Note: the value is still usable after the application domain was unloaded.
            //This means that the integer was COPIED from the target application domain
            //to this application domain.  This is possible because the Int32 type is
            //loaded in both application domains and is marked as serializable.
            Console.WriteLine(intFromOtherDomain);
        }

        /// <summary>
        /// This method demonstrates that an object which is not marked as serializable
        /// (marshal-by-value) or marshal-by-reference cannot be passed across application
        /// domain boundaries.  This demo does not demonstrate the proper way to pass
        /// objects across this boundary - it only shows that it is not as simple as it
        /// may at first appear.
        /// </summary>
        private static void UsingCreateInstanceFails()
        {
            AppDomain domain = AppDomain.CreateDomain("InstanceDomain");
            try
            {
                Rectangle rect = (Rectangle)domain.CreateInstanceAndUnwrap(typeof(Rectangle).Assembly.FullName, typeof(Rectangle).FullName);
                Console.WriteLine("Rectangle area: " + rect.Area);
            }
            catch (SerializationException ex)
            {   //A serialization exception occurs because the Rectangle class
                //is not marked as serializable.  Therefore, there is no safe
                //way to transmit it across application domain boundaries.
                //Note that the Rectangle constructor executes, because there is 
                //no problem with loading the Rectangle type on the other side
                //and creating an instance of it.  The problem begins when the
                //instance is serialized to the caller.
                Console.WriteLine(ex);
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }
    }

    /// <summary>
    /// A sample object used for instantiation in a different application domain.
    /// </summary>
    class Rectangle
    {
        private readonly int _width, _height;

        public Rectangle()
            : this(10, 10)
        {
            Console.WriteLine("Rectangle constructor executes, app domain name: " + AppDomain.CurrentDomain.FriendlyName);
        }

        public Rectangle(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
        public int Area { get { return _width * _height; } }
    }
}
