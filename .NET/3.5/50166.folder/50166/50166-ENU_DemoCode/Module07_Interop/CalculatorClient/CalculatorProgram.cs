using System;
using SimpleCOMCalculatorLib;

namespace CalculatorClient
{
    /// <summary>
    /// Demonstrates accessing the COM type through an interop assembly.
    /// Note that the COM type is instantiated like any other .NET type and
    /// accessed using the COM interface it implements.  The E_INVALIDARG
    /// error is converted to an instance of ArgumentException by the COM
    /// interop layer.
    /// </summary>
    class CalculatorProgram
    {
        static void Main(string[] args)
        {
            ICalculator calculator = new CalculatorClass();

            while (true)
            {
                try
                {
                    Console.Write("Enter first number: ");
                    int first = int.Parse(Console.ReadLine());
                    
                    Console.Write("Enter first number: ");
                    int second = int.Parse(Console.ReadLine());

                    Console.WriteLine("Add result: " + calculator.Add(first, second));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Attempted to add two zeros, exiting.  Last result was: " + calculator.LastResult);
                    break;
                }
            }
        }
    }
}
