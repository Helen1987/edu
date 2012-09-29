using System;
using System.IO;
using System.Threading;

namespace ThreadAndThreadPool
{
    /// <summary>
    /// Demonstrates the creation of threads and the use of the thread pool
    /// for queueing work asynchronously for responsiveness and performance reasons.
    /// </summary>
    class ThreadingExamples
    {
        static void Main(string[] args)
        {
            ThreadPoolDemo();
            //ThreadDemo();
        }

        /// <summary>
        /// Demonstrates how work can be queued asynchronously using the thread pool,
        /// but also shows some of the problems with this approach:
        ///     1) There is no way to receive a notification when the work is complete,
        ///        meaning that the logger.Close() call is relying on sheer luck.
        ///     2) There is no guarantee of synchronization or ordering on the underlying
        ///        stream, so we're seeing output out of order.
        /// </summary>
        private static void ThreadPoolDemo()
        {
            AsyncLogger logger = new AsyncLogger("log.txt");
            for (int i = 0; i < 100; ++i)
            {
                logger.WriteLogAsync(i.ToString() + " ");
            }
            Thread.Sleep(TimeSpan.FromMilliseconds(1));  //Wait for logging to complete
            logger.Close();
            Console.WriteLine(File.ReadAllText("log.txt"));
        }

        /// <summary>
        /// Demonstrates how work can be queued asynchronously to a separate thread
        /// which performs the logging work.  Synchronization on the underlying stream
        /// is guaranteed by the fact that only one thread performs the logging and
        /// takes the items from a queue, so they arrive in-order (guaranteed).
        /// </summary>
        private static void ThreadDemo()
        {
            AsyncLogger2 logger = new AsyncLogger2("log.txt");
            for (int i = 0; i < 100; ++i)
            {
                logger.WriteLogAsync(i.ToString() + " ");
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));  //Wait for logging to complete
            logger.Close();
            Console.WriteLine(File.ReadAllText("log.txt"));
        }
    }
}
