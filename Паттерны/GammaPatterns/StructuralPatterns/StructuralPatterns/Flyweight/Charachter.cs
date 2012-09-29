namespace StructuralPatterns.Flyweight
{
    using System;
    using System.Windows.Forms;

    public class Charachter : Glyph
    {
        private char charCode;

        public Charachter(char symbol)
        {
            this.charCode = symbol;
        }

        public override void Draw(View view, GlyphContext context)
        {
            Console.WriteLine(string.Format("Draw {0} symbol with font {1}", this.charCode, context.GetFont()));
        }
    }
}

