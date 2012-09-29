using System;

namespace DelegatesAndEvents.LoggingFramework
{
    /// <summary>
    /// Indicates that the method decorated by this attribute is the "log method"
    /// for its declaring type.  This is the method that will be used by the dynamic
    /// logging framework presented in this sample to output a log-friendly 
    /// representation of the object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class LogMethodAttribute : Attribute
    {
    }

    public delegate string LogMethodDelegate();
}
