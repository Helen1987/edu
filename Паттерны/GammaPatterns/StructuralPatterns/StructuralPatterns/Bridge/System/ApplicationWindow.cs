using System;
using System.Drawing;
using System.Windows.Forms;

namespace StructuralPatterns.Bridge.System
{


    public class ApplicationWindow : Window
    {
        public ApplicationWindow(View content) : base(content)
        {
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Deiconify()
        {
            throw new NotImplementedException();
        }

        public override void DrawContents()
        {
            Console.WriteLine("Application window -> DrawContents call");
            base.GetWindowImp().DeviceText("Text", 10, 20);
        }

        public override void DrawLine(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }

        public override void DrawPolygon(Point[] array, int n)
        {
            throw new NotImplementedException();
        }

        public override void DrawText(string text, Point p)
        {
            throw new NotImplementedException();
        }

        protected override View GetView()
        {
            throw new NotImplementedException();
        }

        public override void Iconify()
        {
            throw new NotImplementedException();
        }

        public override void Lower()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }

        public override void Raise()
        {
            throw new NotImplementedException();
        }

        public override void SetExtent(Point extent)
        {
            throw new NotImplementedException();
        }

        public override void SetOrigin(Point at)
        {
            throw new NotImplementedException();
        }
    }
}

