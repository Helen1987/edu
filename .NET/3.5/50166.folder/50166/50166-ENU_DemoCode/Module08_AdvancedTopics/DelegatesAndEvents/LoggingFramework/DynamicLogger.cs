using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DelegatesAndEvents.LoggingFramework
{
    /// <summary>
    /// Demonstrates dynamic creation of delegates for efficient method invocation at runtime.
    /// Although it is possible to invoke methods using the MethodInfo instance obtained using
    /// Reflection, it is more efficient by several orders of magnitude to create a delegate 
    /// instance at the first time and reuse that delegate for subsequent invocations.
    /// 
    /// This class stores a mapping between types and a "logger delegate", which is a delegate
    /// referencing a method of the type which "knows" how to construct a log-friendly representation
    /// of the object.  Types opt-in to the dynamic logging mechanism by decorating one of their
    /// methods with a [LogMethod] attribute, indicating to this framework that this method should
    /// be used for logging purposes.
    /// </summary>
    public static class DynamicLogger
    {
        private static Dictionary<Type, LogMethodDelegate> _loggers = new Dictionary<Type, LogMethodDelegate>();

        /// <summary>
        /// Retrieves the logging delegate for the specified object by creating it at runtime.
        /// </summary>
        private static LogMethodDelegate GetLoggerForObject(object @object)
        {
            Type type = @object.GetType();
            LogMethodDelegate logGenerator;
            lock (_loggers)
            {
                //If we already have a logger delegate for this type, return the cached value.
                if (_loggers.TryGetValue(type, out logGenerator))
                {
                    return logGenerator;
                }

                //Obtain the MethodInfo for the log method
                MethodInfo logMethod = (from method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                                        where method.IsDefined(typeof(LogMethodAttribute), false)
                                        select method).SingleOrDefault();
                if (logMethod == null)
                {
                    logGenerator = null;
                }
                else
                {
                    //Use the MethodInfo to create a delegate at runtime, which is now bound to the
                    //logGenerator delegate and can be used to invoke the method in a strongly-typed fashion.
                    logGenerator = (LogMethodDelegate)Delegate.CreateDelegate(typeof(LogMethodDelegate), @object, logMethod);
                }

                //Cache the result for future invocations.
                _loggers.Add(type, logGenerator);
                return logGenerator;
            }
        }

        public static void Log(TextWriter writer, object @object)
        {
            if (@object == null)
            {
                writer.WriteLine("(null)");
                return;
            }

            LogMethodDelegate logGenerator = GetLoggerForObject(@object);
            if (logGenerator == null)
            {
                writer.WriteLine(@object.ToString());
            }
            else
            {
                writer.WriteLine(logGenerator());
            }
        }
    }
}
