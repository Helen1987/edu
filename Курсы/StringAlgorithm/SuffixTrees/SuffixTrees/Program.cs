using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private class FastScanner
    {
        public string Next()
        {
            return Console.ReadLine();
        }

        public int NextInt()
        {
            return Int32.Parse(this.Next());
        }
    }

    public class Trie {
        IList<Dictionary<char, int>> trie;
        int nodesCounter = 0;

        private int AddNewEdge(int nodeId, char symbol)
        {
            if (trie[nodeId].ContainsKey(symbol))
            {
                return trie[nodeId][symbol];
            }
            trie[nodeId].Add(symbol, ++nodesCounter);
            trie.Add(new Dictionary<char, int>());
            return nodesCounter;
        }

        private void AddPattern(string pattern) {
            int nextNode = 0;
            for (int i = 0; i < pattern.Length; ++i) {
                nextNode = AddNewEdge(nextNode, pattern[i]);
            }
        }

        public Trie(string[] patterns) {
            trie = new List<Dictionary<char, int>>();
            trie.Add(new Dictionary<char, int>());

            foreach (string pattern in patterns){
                AddPattern(pattern);
            }
        }

        public void Print()
        {
            for (int i = 0; i < trie.Count(); ++i)
            {
                Dictionary<char, int> node = trie[i];
                foreach (var pair in node)
                {
                    Console.WriteLine("{0}->{1}:{2}", i, pair.Value, pair.Key);
                }
            }
        }

    }

    static void Main(string[] args)
    {
        Run();
    }

    public static void Run()
    {
        FastScanner scanner = new FastScanner();
        int patternsCount = scanner.NextInt();
        String[] patterns = new String[patternsCount];
        for (int i = 0; i < patternsCount; ++i)
        {
            patterns[i] = scanner.Next();
        }
        Trie trie = new Trie(patterns);
        trie.Print();
    }
}
