using StructuralPatterns.Bridge.Imp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StructuralPatterns.Bridge.System
{

    public class IconWindow : Window
    {
        private string bitmapName;

        public IconWindow(View content) : base(content)
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
            IWindowImp imp = base.GetWindowImp();
            if (imp != null)
            {
                imp.DeviceBitmap(this.bitmapName, 0, 0);
            }
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
        }
    }
}

