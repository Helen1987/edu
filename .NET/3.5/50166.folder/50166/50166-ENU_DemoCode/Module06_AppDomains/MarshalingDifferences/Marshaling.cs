using System;

namespace MarshalingDifferences
{
    /// <summary>
    /// This demo shows the difference between marshaling objects by value as opposed
    /// to marshaling objects by reference.  Two versions of the Rectangle class, one
    /// called RectangleMBV and another called RectangleMBR demonstrate that an MBV
    /// object is copied across application domain boundaries, while an MBR object is
    /// referenced from other application domains and can be changed from other application
    /// domains as if it belonged there.
    /// </summary>
    class Marshaling
    {
        static void Main(string[] args)
        {
            MarshalByValue();
            MarshalByReference();
        }

        /// <summary>
        /// Demonstrates that a marshal-by-value instance created and copied from another
        /// application domain is a local copy which does not affect the original object
        /// belonging in its own domain.  The DomainRepresentative class is used to create
        /// an instance within the other application domain and to display its contents.
        /// </summary>
        private static void MarshalByValue()
        {
            AppDomain domain = AppDomain.CreateDomain("MBV");
            DomainRepresentative rep = (DomainRepresentative)domain.CreateInstanceAndUnwrap(
                typeof(DomainRepresentative).Assembly.FullName, typeof(DomainRepresentative).FullName);
            
            RectangleMBV copy = rep.GetRectangleMBV();
            Console.WriteLine("Local instance: " + copy);
            rep.PrintRectangleMBV();

            //The remote instance is not affected by these lines because
            //we're working with a local copy that was passed to us by value.
            //This is the essence of marshal-by-value.
            copy.Height = 5;
            copy.Width = 6;
            Console.WriteLine("Local instance: " + copy);
            rep.PrintRectangleMBV();
        }

        /// <summary>
        /// Demonstrates that a marshal-by-reference instance is not copied from its application
        /// domain, but instead a reference to it is passed to the caller.  Changes made to
        /// the reference (also called a proxy) affect the original object which still resides
        /// in its domain of origin.
        /// </summary>
        private static void MarshalByReference()
        {
            AppDomain domain = AppDomain.CreateDomain("MBR");
            DomainRepresentative rep = (DomainRepresentative)domain.CreateInstanceAndUnwrap(
                typeof(DomainRepresentative).Assembly.FullName, typeof(DomainRepresentative).FullName);

            RectangleMBR proxy = rep.GetRectangleMBR();
            Console.WriteLine("Local instance: " + proxy);
            rep.PrintRectangleMBR();

            //The remote instance is affected by our work on the Height
            //and Width properties because we have a local proxy to the object
            //which actually lives in another application domain.  There is 
            //only one instance of the RectangleMBR class here - it's in
            //the second domain!  We're working with a cross-domain reference
            //to it, and that's the essence of marshal-by-reference.
            proxy.Height = 5;
            proxy.Width = 6;
            Console.WriteLine("Local instance: " + proxy);
            rep.PrintRectangleMBR();
        }
    }

    /// <summary>
    /// This class is used to retrieve information about objects that belong
    /// to a different application domain.  It contains a RectangleMBV and a
    /// RectangleMBR instance and allows for outputting their information, thus
    /// making the difference between MBV and MBR behavior evident.
    /// </summary>
    class DomainRepresentative : MarshalByRefObject
    {
        private RectangleMBV _rectMBV = new RectangleMBV(15, 15);
        private RectangleMBR _rectMBR = new RectangleMBR(15, 15);

        public RectangleMBV GetRectangleMBV()
        {
            return _rectMBV;
        }

        public void PrintRectangleMBV()
        {
            Console.WriteLine("Remote instance: " + _rectMBV);
        }

        public RectangleMBR GetRectangleMBR()
        {
            return _rectMBR;
        }

        public void PrintRectangleMBR()
        {
            Console.WriteLine("Remote instance: " + _rectMBR);
        }
    }
    
    /// <summary>
    /// A serializable Rectangle class that demonstrates marshal-by-value
    /// behavior.  When passed across application domain boundaries, this
    /// class is copied using serialization.
    /// </summary>
    [Serializable]
    class RectangleMBV
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public RectangleMBV()
            : this(10, 10)
        {
        }

        public RectangleMBV(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Area { get { return Width * Height; } }

        public override string ToString()
        {
            return String.Format("w={0}, h={1}, wxh={2}", Width, Height, Area);
        }
    }

    /// <summary>
    /// A marshal-by-reference Rectangle class that demonstrates marshal-by-reference
    /// behavior.  When passed across application domain boundaries, a proxy (reference)
    /// to the object is passed without copying its contents.
    /// </summary>
    class RectangleMBR : MarshalByRefObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public RectangleMBR()
            : this(10, 10)
        {
        }

        public RectangleMBR(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Area { get { return Width * Height; } }

        public override string ToString()
        {
            return String.Format("w={0}, h={1}, wxh={2}", Width, Height, Area);
        }
    }
}
