namespace StructuralPatterns.Facade
{
    using System;
    using System.IO;

    public class Scanner
    {
        private FileStream inputStream;

        public Scanner(FileStream stream)
        {
            this.inputStream = stream;
        }

        public virtual Token Scan()
        {
            return null;
        }
    }
}

