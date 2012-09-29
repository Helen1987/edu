namespace StructuralPatterns.Decorator
{
    using System;

    public class ConcreteDecorator : StructuralPatterns.Decorator.Decorator
    {
        public ConcreteDecorator(IComponent parent) : base(parent)
        {
        }

        protected void AddedBehavior()
        {
        }

        public void Display()
        {
            base.Display();
            this.AddedBehavior();
        }
    }
}

