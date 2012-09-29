using System;
using System.Drawing;

namespace StructuralPatterns.Bridge.Imp
{


    public interface IWindowImp
    {
        void DeviceBitmap(string text, Coord c1, Coord c2);
        void DeviceRect(Coord c1, Coord c2, Coord c3, Coord c4);
        void DeviceText(string text, Coord c1, Coord c2);
        void ImpBottom();
        void ImpSetExtent(Point p);
        void ImpSetOrigin(Point p);
        void ImpTop();
    }
}

