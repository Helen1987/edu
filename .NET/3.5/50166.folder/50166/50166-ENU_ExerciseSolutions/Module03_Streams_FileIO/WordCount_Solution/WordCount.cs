using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount_Solution
{
    /// <summary>
    /// Parses a command line string looking for positional arguments
    /// at the beginning of the command line string, followed by named
    /// argument which are formatted as follows:
    ///     -argname:argvalue
    /// </summary>
    class CommandLineParser
    {
        private readonly string[] _args;
        private readonly int _positional;
        private Dictionary<string, string> _named = new Dictionary<string, string>();

        public CommandLineParser(string[] args)
        {
            _args = args;
            foreach (string arg in args)
            {
                if (!arg.StartsWith("-"))
                    _positional++;
                else
                {
                    int colon = arg.IndexOf(':');
                    _named.Add(arg.Substring(1, colon - 1), arg.Substring(colon + 1, arg.Length - colon));
                }
            }
        }

        /// <summary>
        /// Count of positional arguments.
        /// </summary>
        public int PositionalArguments
        {
            get
            {
                return _positional;
            }
        }

        public string GetPositionalArgument(int index)
        {
            return _args[index];
        }

        /// <summary>
        /// Retrieves a named argument by its key name.
        /// </summary>
        /// <param name="key">The key name.</param>
        /// <returns>The value of the named argument or an empty string
        /// if there is no such named argument.</returns>
        public string GetNamedArgument(string key)
        {
            string val = String.Empty;
            _named.TryGetValue(key, out val);
            return val;
        }
    }

    class WordCount
    {
        static void Main(string[] args)
        {
            WordCount wc = new WordCount(args);
            wc.Run();
        }

        private readonly TextWriter _textOutputStream;
        private readonly BinaryWriter _binaryOutputStream;
        private readonly Dictionary<string, int> _wordCounts = new Dictionary<string, int>();

        /// <summary>
        /// Prepares the word count program for execution.
        /// </summary>
        /// <param name="args">Command line arguments, in the following format:
        /// WordCount.exe file1 [file2 [file3...]] [-t:summary.txt] [-b:summary.bin]
        /// The default output text stream is Console.Out, and there is no default
        /// output binary stream.</param>
        private WordCount(string[] args)
        {
            CommandLineParser parser = new CommandLineParser(args);
            for (int i = 0; i < parser.PositionalArguments; ++i)
            {
                _wordCounts.Add(parser.GetPositionalArgument(i), 0);
            }

            string textOut;
            if (!String.IsNullOrEmpty(textOut = parser.GetNamedArgument("t")))
            {
                _textOutputStream = File.CreateText(textOut);
            }
            else
            {
                _textOutputStream = Console.Out;
            }

            string binaryOut;
            if (!String.IsNullOrEmpty(binaryOut = parser.GetNamedArgument("b")))
            {
                _binaryOutputStream = new BinaryWriter(File.Create(binaryOut));
            }
        }

        private void Run()
        {
            foreach (string file in _wordCounts.Keys.ToArray() /*Clone the keys collection so we can modify the dictionary*/)
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _wordCounts[file] += line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                    }
                }
                _textOutputStream.WriteLine("{0}\t{1}", file, _wordCounts[file]);
                if (_binaryOutputStream != null)
                    _binaryOutputStream.Write(_wordCounts[file]);
            }

            if (_textOutputStream != Console.Out)
                _textOutputStream.Close();
            if (_binaryOutputStream != null)
                _binaryOutputStream.Close();
        }
    }
}
