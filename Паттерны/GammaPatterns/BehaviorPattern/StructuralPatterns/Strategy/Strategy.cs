namespace StructuralPatterns.Strategy
{
    using System;

    public abstract class Strategy
    {
        protected Strategy()
        {
        }

        public abstract void Operation();
    }
}

