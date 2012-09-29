using System;
using System.Collections.Generic;
using System.Linq;

namespace APM
{
    /// <summary>
    /// The type of prime number calculation to perform.
    /// </summary>
    enum PrimeNumberCalculation
    {
        /// <summary>
        /// Use the Sieve of Erastothenes to calculate prime numbers
        /// within a range.
        /// http://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        /// </summary>
        Sieve,
        /// <summary>
        /// Use the standard (up-to-square-root) method to calculate prime
        /// numbers within a range.
        /// http://en.wikipedia.org/wiki/Trial_division
        /// </summary>
        Standard
    }

    /// <summary>
    /// Encapsulates a prime number calculations within a range of integers.
    /// </summary>
    class PrimeNumberCalculator
    {
        private readonly int _start, _end;
        private IEnumerable<int> _thePrimes;

        /// <summary>
        /// The number of elements in the range.
        /// </summary>
        public int Range { get { return _end - _start; } }

        /// <summary>
        /// The actual prime numbers in the range.
        /// </summary>
        public IEnumerable<int> ThePrimes
        {
            get { return _thePrimes; }
        }

        public PrimeNumberCalculator(int start, int end)
        {
            _start = start;
            _end = end;
        }

        /// <summary>
        /// Performs the calculation and returns the number of prime numbers
        /// in the range.  The numbers themselves can be retrieved using the
        /// ThePrimes property.
        /// </summary>
        /// <param name="method">The method to use for calculation.</param>
        /// <returns>The number of prime numbers in the range.</returns>
        public int Calculate(PrimeNumberCalculation method)
        {
            switch (method)
            {
                case PrimeNumberCalculation.Sieve:
                    {
                        bool[] composites = new bool[Range];
                        int sqrt = (int)Math.Ceiling(Math.Sqrt(_end));
                        for (int i = 2; i <= sqrt; ++i)
                        {
                            if (!IsPrime(i)) continue;
                            composites[i] = false;
                            for (int j = i * 2; j < Range; j += i)
                                composites[j] = true;
                        }
                        _thePrimes = composites.IndexesSuchAs(p => !p).Add(_start);
                        return _thePrimes.Count();  //This causes evaluation of the enumerable
                    }

                case PrimeNumberCalculation.Standard:
                    _thePrimes = Enumerable.Range(_start, Range).Where(IsPrime);
                    return _thePrimes.Count();  //This causes evaluation of the enumerable

                default:
                    return -1;
            }
        }

        private static bool IsPrime(int number)
        {
            if (number % 2 == 0)
                return false;

            int sqrt = (int)Math.Ceiling(Math.Sqrt(number));
            for (int i = 3; i <= sqrt; i += 2)
                if (number % i == 0) return false;

            return true;
        }
    }
}
