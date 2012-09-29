namespace StructuralPatterns.Strategy
{
    using System;

    public class Component
    {
        private StructuralPatterns.Strategy.Strategy strategy;

        public Component(StructuralPatterns.Strategy.Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void Operation()
        {
            this.strategy.Operation();
        }
    }
}

