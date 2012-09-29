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
        
        //Denotes that all worker threads are done:
        private static CountdownEvent _allThreadsDone;

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
                    _work.Enqueue(new WorkItem<string>(line));
                }
            }
            for (int i = 0; i < DegreeOfParallelism; ++i)
            {
                _work.Enqueue(WorkItem<string>.Done);
            }
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
                WorkItem<string> line = _work.Dequeue();
                if (line.IsWorkDone)
                    break;

                //Simulate some work:
                _wordCounts.Enqueue(line.Work.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length);
            }
            _allThreadsDone.Set();
        }

        /// <summary>
        /// Creates the reader and processor threads, waits for them to finish
        /// the work and then prints the sum of the results from the result queue.
        /// </summary>
        static void Main()
        {
            _allThreadsDone = new CountdownEvent(DegreeOfParallelism);

            new Thread(Reader).Start();
            for (int i = 0; i < DegreeOfParallelism; ++i)
            {
                new Thread(Processor).Start();
            }

            _allThreadsDone.Wait();

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
