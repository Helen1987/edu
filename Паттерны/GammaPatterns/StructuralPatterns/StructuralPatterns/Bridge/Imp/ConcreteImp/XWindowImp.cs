using StructuralPatterns.Bridge.Imp;
using System;
using System.Drawing;

namespace StructuralPatterns.Bridge.Imp.ConcreteImp
{
    public class XWindowImp : IWindowImp
    {
        public void DeviceBitmap(string text, Coord c1, Coord c2)
        {
            throw new NotImplementedException();
        }

        public void DeviceRect(Coord x0, Coord y0, Coord x1, Coord y1)
        {
            int x = (int) Math.Round(Math.Min((double) x0.Value, (double) x1.Value));
            int y = (int) Math.Round(Math.Min((double) x0.Value, (double) x1.Value));
            int w = (int) Math.Round(Math.Min((double) x0.Value, (double) x1.Value));
            int h = (int) Math.Round(Math.Min((double) x0.Value, (double) x1.Value));
        }

        public void DeviceText(string text, Coord c1, Coord c2)
        {
            Console.WriteLine("XWindowImp->DeviceText");
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

