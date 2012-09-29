namespace StructuralPatterns.Flyweight
{
    using System;
    using System.Collections.Generic;

    public class GlyphFactory
    {
        private const int BeginChar = 100;
        private IDictionary<char, Charachter> characters = new Dictionary<char, Charachter>(100);
        private const int EndChar = 200;

        public virtual Charachter CreateCharacter(char character)
        {
            if (!this.characters.ContainsKey(character))
            {
                this.characters[character] = new Charachter(character);
            }
            Console.WriteLine("Flyweight object");
            return this.characters[character];
        }

        public virtual Column CreateColumn()
        {
            Console.WriteLine("Not flyweight object");
            return new Column();
        }

        public virtual Row CreateRow()
        {
            Console.WriteLine("Not flyweight object");
            return new Row();
        }
    }
}

