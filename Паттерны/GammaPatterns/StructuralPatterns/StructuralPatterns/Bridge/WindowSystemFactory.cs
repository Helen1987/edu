namespace StructuralPatterns.Bridge
{
    using StructuralPatterns.Bridge.Imp;
    using StructuralPatterns.Bridge.Imp.ConcreteImp;
    using System;

    public class WindowSystemFactory
    {
        private static WindowSystemFactory factory;

        private WindowSystemFactory()
        {
        }

        public IWindowImp GetWindowImp()
        {
            return new XWindowImp();
        }

        public static WindowSystemFactory Instance()
        {
            if (factory == null)
            {
                factory = new WindowSystemFactory();
            }
            return factory;
        }
    }
}

