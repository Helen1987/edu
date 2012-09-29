using System;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class E : System.Linq.Expressions.

    class Program
    {
        static void Main(string[] args)
        {


            Dict dict = new Dict();

            string s = "hello";

            var words = from word in dict.Match
                        where word.Contains("word")
                        select word;

            var wordsCount = Enumerable.Count(words);

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }


    }
}
