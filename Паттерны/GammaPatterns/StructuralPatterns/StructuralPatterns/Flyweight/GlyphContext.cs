using System;
using System.Drawing;

using System.Runtime.InteropServices;

namespace StructuralPatterns.Flyweight
{


    public class GlyphContext
    {
        private int index;
        private BinaryExpression tree;

        public virtual Font GetFont()
        {
            return null;
        }

        public virtual void Insert(int quantity = 1)
        {
            this.index += quantity;
        }

        public virtual void Next(int step = 1)
        {
            this.index += step;
        }

        public virtual void SetFont(Font font, int span = 1)
        {
            Console.WriteLine(string.Format("Set font {0} at position {1}", font, this.index));
        }
    }
}

