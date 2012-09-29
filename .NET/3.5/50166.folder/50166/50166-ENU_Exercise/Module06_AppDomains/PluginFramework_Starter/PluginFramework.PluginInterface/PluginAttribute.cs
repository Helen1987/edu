using System;

namespace PluginFramework.PluginInterface
{
    public enum Complexity
    {
        Linear,
        Quadratic
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class PluginAttribute : Attribute
    {
        private readonly string _name;
        private readonly Complexity _complexity;

        public PluginAttribute(string name)
            : this(name, Complexity.Linear)
        {
        }

        public PluginAttribute(string name, Complexity complexity)
        {
            _name = name;
            _complexity = complexity;
        }

        public string Name { get { return _name; } }
    }
}
