namespace StructuralPatterns.Bridge.Imp
{
    using System;

    public class Coord
    {
        private int coord;

        public Coord(int x)
        {
            this.coord = x;
        }

        public static implicit operator Coord(int x)
        {
            return new Coord(x);
        }

        public int Value
        {
            get
            {
                return this.coord;
            }
        }
    }
}

