namespace StructuralPatterns.Adapter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class TextAdapterObject : IGraphicInterface
    {
        private TextBox textBox = new TextBox();

        public void Draw()
        {
        }

        public void SetPosition(int x, int y)
        {
            this.textBox.Location = new Point(x, y);
        }
    }
}

