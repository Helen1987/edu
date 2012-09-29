namespace StructuralPatterns.Adapter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class TextAdapterClass : TextBox, IGraphicInterface
    {
        public void Draw()
        {
            this.Draw();
        }

        public void SetPosition(int x, int y)
        {
            base.Location = new Point(x, y);
        }
    }
}

