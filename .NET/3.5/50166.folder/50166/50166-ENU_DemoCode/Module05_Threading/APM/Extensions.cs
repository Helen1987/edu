using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace APM
{
    class Printer
    {
        public void Print(int result)
        {
            Console.WriteLine("The result is: " + result);
        }
    }

    /// <summary>
    /// Contains a convenience method for measuring the time it takes
    /// a piece of code to run and then printing the time to the console
    /// (in milliseconds).
    /// </summary>
    static class Measure
    {
        public static void It(Action action, string description)
        {
            Stopwatch sw = Stopwatch.StartNew();
            action();
            Console.WriteLine("Action {0} took {1}ms", description, sw.ElapsedMilliseconds);
        }
    }

    /// <summary>
    /// Enumerable extensions.  Each extension is self-explanatory.
    /// </summary>
    public static class Extensions
    {
        public static IEnumerable<int> Add(this IEnumerable<int> coll, int value)
        {
            foreach (int item in coll)
                yield return item + value;
        }

        public static void ForEach<T>(this IEnumerable<T> coll, Action<T> action)
        {
            foreach (T item in coll)
                action(item);
        }

        public static IEnumerable<int> IndexesSuchAs<T>(this IEnumerable<T> coll, Predicate<T> pred)
        {
            IEnumerator<T> enumerator = coll.GetEnumerator();
            for (int i = 0; enumerator.MoveNext(); ++i)
            {
                if (pred(enumerator.Current))
                    yield return i;
            }
        }
    }
}