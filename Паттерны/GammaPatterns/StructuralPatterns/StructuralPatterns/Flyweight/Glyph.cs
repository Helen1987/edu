namespace StructuralPatterns.Flyweight
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class Glyph
    {
        protected Glyph()
        {
        }

        public virtual Glyph Current(GlyphContext context)
        {
            return this;
        }

        public virtual void Draw(View view, GlyphContext context)
        {
            Console.WriteLine(string.Format("Draw glyph with font {0}", context.GetFont()));
        }

        public virtual void First(GlyphContext context)
        {
        }

        public virtual Font GetFont(GlyphContext context)
        {
            return context.GetFont();
        }

        public void Insert(Glyph glyph, GlyphContext context)
        {
            context.Insert(1);
        }

        public virtual bool IsDone(GlyphContext context)
        {
            return true;
        }

        public virtual void Next(GlyphContext context)
        {
            context.Next(1);
        }

        public void Remove(GlyphContext context)
        {
        }

        public virtual void SetFont(Font font, GlyphContext context)
        {
            context.SetFont(font, 1);
        }
    }
}

