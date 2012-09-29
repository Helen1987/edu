using System;
using System.IO;
using System.Threading;

namespace QueuingWork
{
    class QueuingWorkMain
    {
        //Queues for the work in progress and for the results.
        private static ThreadSafeQueue<WorkItem<string>> _work = new ThreadSafeQueue<WorkItem<string>>();
        private static ThreadSafeQueue<int> _wordCounts = new ThreadSafeQueue<int>();

        //The degree-of-parallelism: how many threads will be created to process the text.
        private static readonly int DegreeOfParallelism = Environment.ProcessorCount;

        /// <summary>
        /// Reads text from a file line-after-line and enqueues the work to the queue
        /// for processor threads to process.  When there is no more work, enqueues
        /// the necessarily number of "end-of-work" work items so that all processor 
        /// threads know that they are done.
        /// </summary>
        static void Reader()
        {
            using (StreamReader reader = new StreamReader(@"..\..\LotsOfText.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Simulate some work:
                    Thread.Sleep(1);
                    
                    //TODO: Enqueue the work item to the work item queue.
                }
            }
            
            //TODO: For each processor thread, enqueue the special "end-of-work" work item.
        }

        /// <summary>
        /// Processes items from the work queue and enqueues results into
        /// the results queue until the special "end-of-work" work item condition
        /// has been encountered.
        /// </summary>
        static void Processor()
        {
            while (true)
            {
                //TODO: Dequeue work from the work item queue and break the loop
                //if it's the special "end-of-work" work item.

                //Simulate some work:
                Thread.Sleep(1);
                
                //TODO: Enqueue the number of words in the line to the result queue.
            }
        }

        /// <summary>
        /// Creates the reader and processor threads, waits for them to finish
        /// the work and then prints the sum of the results from the result queue.
        /// </summary>
        static void Main()
        {
            //TODO: Create one reader thread and the number of processor threads
            //specified by the DegreeOfParallelism field.

            //TODO: Wait for all threads to complete.

            int sum = 0;
            //Here we can use UnsafeItems to access the queue because we know
            //for sure that all concurrent work on it has finished.
            foreach (int wc in _wordCounts.UnsafeItems)
            {
                sum += wc;
            }
            Console.WriteLine("Total words: " + sum);
        }
    }
}
