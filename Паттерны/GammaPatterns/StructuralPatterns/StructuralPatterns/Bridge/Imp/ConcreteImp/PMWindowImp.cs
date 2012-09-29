using StructuralPatterns.Bridge.Imp;
using System;
using System.Drawing;

namespace StructuralPatterns.Bridge.Imp.ConcreteImp
{
    public class PMWindowImp : IWindowImp
    {
        public void DeviceBitmap(string text, Coord c1, Coord c2)
        {
            throw new NotImplementedException();
        }

        public void DeviceRect(Coord x0, Coord y0, Coord x1, Coord y1)
        {
            Coord left = Math.Min(x0.Value, x1.Value);
            Coord right = Math.Max(x0.Value, x1.Value);
            Coord botom = Math.Min(y0.Value, y1.Value);
            Coord top = Math.Max(y0.Value, y1.Value);
        }

        public void DeviceText(string text, Coord c1, Coord c2)
        {
            Console.WriteLine("PMWindowImp->DeviceText");
        }

        public void ImpBottom()
        {
            throw new NotImplementedException();
        }

        public void ImpSetExtent(Point p)
        {
            throw new NotImplementedException();
        }

        public void ImpSetOrigin(Point p)
        {
            throw new NotImplementedException();
        }

        public void ImpTop()
        {
            throw new NotImplementedException();
        }
    }
}

