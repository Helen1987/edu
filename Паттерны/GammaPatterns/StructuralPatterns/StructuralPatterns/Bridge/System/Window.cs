using StructuralPatterns.Bridge;
using StructuralPatterns.Bridge.Imp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StructuralPatterns.Bridge.System
{
    public abstract class Window
    {
        private View content;
        private IWindowImp implementation;

        public Window(View content)
        {
            this.content = content;
        }

        public abstract void Close();
        public abstract void Deiconify();
        public abstract void DrawContents();
        public abstract void DrawLine(Point p1, Point p2);
        public abstract void DrawPolygon(Point[] array, int n);
        public virtual void DrawRect(Point p1, Point p2)
        {
            this.GetWindowImp().DeviceRect(p1.X, p1.Y, p2.X, p2.Y);
        }

        public abstract void DrawText(string text, Point p);
        protected abstract View GetView();
        protected IWindowImp GetWindowImp()
        {
            if (this.implementation == null)
            {
                this.implementation = WindowSystemFactory.Instance().GetWindowImp();
            }
            return this.implementation;
        }

        public abstract void Iconify();
        public abstract void Lower();
        public abstract void Open();
        public abstract void Raise();
        public abstract void SetExtent(Point extent);
        public abstract void SetOrigin(Point at);
    }
}

