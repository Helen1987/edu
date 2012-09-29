using System;
using System.IO;
using System.Runtime.Remoting.Messaging;    //For AsyncResult
using System.Threading;

namespace APM
{
    /// <summary>
    /// Demonstrates various uses of the .NET Asynchronous Programming Model,
    /// with a focus on files and on arbitrary delegates.  Shows the various ways
    /// to end an asynchronous invocation (waiting, polling, callback etc.).
    /// </summary>
    class APMExamples
    {
        static void Main(string[] args)
        {
            CreateLargeFile();
            APMWithFiles();
            APMWithDelegates();
            APMVariousWaysToEnd();
        }

        /// <summary>
        /// Creates a large file for demonstration purposes.
        /// </summary>
        private static void CreateLargeFile()
        {
            using (StreamWriter writer = new StreamWriter("sample.txt"))
            {
                for (int i = 0; i < 5000000; ++i)
                {
                    writer.WriteLine(i);
                }
            }
        }

        /// <summary>
        /// Demonstrates the use of the APM with files, through the FileStream class.
        /// This method performs asynchronous reads and writes to copy data from an input
        /// file to an output file.  Reads and writes are interlaced, and proceed in chunks
        /// of 8KB at a time (displaying progress to the console).
        /// </summary>
        static void APMWithFiles()
        {
            FileStream reader = new FileStream("sample.txt", FileMode.Open);
            FileStream writer = new FileStream("sample2.txt", FileMode.Create);
            byte[] buffer1 = new byte[8192], buffer2 = new byte[8192];
            IAsyncResult ar1, ar2 = null;
            while (true)
            {
                ar1 = reader.BeginRead(buffer1, 0, buffer1.Length, null, null);
                while (!ar1.IsCompleted)
                {
                    Console.Write("R");
                }
                if (ar2 != null)
                {
                    while (!ar2.IsCompleted)
                    {
                        Console.Write("W");
                    }
                }
                int bytesRead;
                if ((bytesRead = reader.EndRead(ar1)) == 0)
                    break;  //No more data to read
                if (ar2 != null)
                {
                    writer.EndWrite(ar2);
                }
                Array.Copy(buffer1, buffer2, bytesRead);
                ar2 = writer.BeginWrite(buffer2, 0, bytesRead, null, null);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates the use of the APM with arbitrary delegates for performing
        /// a prime number calculation.  The code performs a synchronous calculation first,
        /// and then interlaces two different calculation methods asynchronously and
        /// waits for them to complete.
        /// </summary>
        static void APMWithDelegates()
        {
            //Synchronous calculation:
            PrimeNumberCalculator calc = new PrimeNumberCalculator(5, 10000000);
            Measure.It(() =>
            {
                Console.WriteLine("There are {0} primes using the sieve", calc.Calculate(PrimeNumberCalculation.Sieve));
            }, "Synchronous calculation");

            //Asynchronous calculation using delegates to perform BOTH calculations at the same time:
            Measure.It(delegate
            {
                PrimeNumberCalculator asyncSieve = new PrimeNumberCalculator(5, 10000000);
                Func<PrimeNumberCalculation, int> asyncSieveCalculate = asyncSieve.Calculate;
                IAsyncResult sieveAR = asyncSieveCalculate.BeginInvoke(PrimeNumberCalculation.Sieve, null, null);

                PrimeNumberCalculator asyncStandard = new PrimeNumberCalculator(5, 10000000);
                Func<PrimeNumberCalculation, int> asyncStandardCalculate = asyncStandard.Calculate;
                IAsyncResult standardAR = asyncStandardCalculate.BeginInvoke(PrimeNumberCalculation.Sieve, null, null);

                //Polling the IsCompleted property of both async results every 100ms:
                while (!(sieveAR.IsCompleted && standardAR.IsCompleted))
                    Thread.Sleep(100);

                Console.WriteLine("There are {0} primes using the sieve", asyncSieveCalculate.EndInvoke(sieveAR));
                Console.WriteLine("There are {0} primes using the standard method", asyncStandardCalculate.EndInvoke(standardAR));

            }, "Asynchronous calculation using both methods");
        }

        /// <summary>
        /// Demonstrates the various ways to poll for asynchronous work to complete:
        /// Using the IsCompleted property, waiting for the wait handle embedded in the
        /// IAsyncResult object, and using a callback that is invoked when the operation
        /// completes.  Both an anonymous method and a regular method are used as callbacks.
        /// </summary>
        private static void APMVariousWaysToEnd()
        {
            PrimeNumberCalculator calc = new PrimeNumberCalculator(5, 100000);
            Func<PrimeNumberCalculation, int> invoker = calc.Calculate;

            //Poll for IsCompleted property:
            IAsyncResult ar = invoker.BeginInvoke(PrimeNumberCalculation.Sieve, null, null);
            while (!ar.IsCompleted)
                Thread.Sleep(100);
            int result = invoker.EndInvoke(ar);

            //Wait for the wait handle:
            ar = invoker.BeginInvoke(PrimeNumberCalculation.Sieve, null, null);
            ar.AsyncWaitHandle.WaitOne();
            result = invoker.EndInvoke(ar);

            //Use callback
            ar = invoker.BeginInvoke(PrimeNumberCalculation.Sieve, delegate
            {
                //Note that because we're using a closure (anonymous method),
                //we have access to the enclosing scope, so we don't have to 
                //think about how the invoker and ar variables end up inside the
                //callback method.
                result = invoker.EndInvoke(ar);
            }, null);

            //Use callback without closures:
            Printer printer = new Printer();
            ar = invoker.BeginInvoke(PrimeNumberCalculation.Sieve, new AsyncCallback(CalculationEnded), printer);
        }

        private static void CalculationEnded(IAsyncResult ar)
        {
            //We need to retrieve the delegate and the state:
            AsyncResult realAR = (AsyncResult)ar;
            Printer printer = (Printer)ar.AsyncState;
            var invoker = (Func<PrimeNumberCalculation, int>)realAR.AsyncDelegate;
            //End the operation and print the result:
            int result = invoker.EndInvoke(ar);
            printer.Print(result);
        }
    }
}
