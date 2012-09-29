namespace StructuralPatterns.Decorator
{
    using System;

    public abstract class Decorator : IComponent
    {
        private IComponent innerObject;

        public Decorator(IComponent parent)
        {
            this.innerObject = parent;
        }

        public void Display()
        {
            this.innerObject.Display();
        }
    }
}

