using System;
using System.Threading;

namespace Synchronization
{
    /// <summary>
    /// Demonstrates various synchronization mechanisms as well as the need
    /// for synchronization and potential pitfalls when using synchronization.
    /// </summary>
    class SyncDemo
    {
        static void Main(string[] args)
        {
            //TheNeedForSynchronization();
            //VolatileVariables();
            //InterlockedSynchronization();
            //LockSynchronization();
            //Deadlocks();
            //PulseAndWait();
            AdvancedSynchronization();
        }
        
        /// <summary>
        /// Shows that it is possible for a shared variable that is modified without
        /// synchronization to become corrupted.  In this case, a counter is incremented
        /// a certain number of times in parallel, but the resulting value is not
        /// necessarily what we expect.
        /// </summary>
        private static void TheNeedForSynchronization()
        {
            Counter globalCounter = new Counter();

            for (int i = 0; i < PARALLELISM; ++i)
            {
                ThreadPool.QueueUserWorkItem(IncrementCounterLotsOfTimes, globalCounter);
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Expected: {0}, actual: {1}", PARALLELISM * INCREMENTS, globalCounter.Current);
        }

        const int INCREMENTS = 10000;
        const int PARALLELISM = 10;

        private static void IncrementCounterLotsOfTimes(object obj)
        {
            Counter counter = (Counter)obj;
            for (int i = 0; i < INCREMENTS; ++i)
                counter.Next();
            Console.WriteLine("Completed");
        }

        /// <summary>
        /// Demonstrates that variables intended for sharing between threads must be
        /// marked as volatile.  In this example, a thread does not see updates to a
        /// non-volatile variable because of optimizations which the compiler is free
        /// to perform.
        /// </summary>
        private static void VolatileVariables()
        {
            //This code does not cause the thread pool work item to stop
            //although the stop flag is set to true.  This happens in Release
            //mode, and the reason is that the 'stop' flag access is optimized
            //away if the variable is not volatile.
            //Marking the 'stop' variable as volatile would fix this problem,
            //but local variables cannot be marked as volatile.  Making the
            //variable a class-level static member and marking it as volatile
            //is the real fix.  Another option is using the Thread.VolatileRead
            //API, which performs a dynamic volatile read on a memory address
            //that does not necessarily belong to a volatile variable.
            bool stop = false;
            ThreadPool.QueueUserWorkItem(delegate
            {
                while (!stop) ;
                Console.WriteLine("Done");
            });
            Console.Write("Hit RETURN to stop the thread and expect 'Done' to be printed."); Console.ReadLine();
            stop = true;
            Console.Write("Hit RETURN to continue."); Console.ReadLine();
        }

        /// <summary>
        /// Demonstrates how interlocked synchronization is used to ensure that a 
        /// counter variable is incremented atomically.
        /// </summary>
        private static void InterlockedSynchronization()
        {
            InterlockedCounter globalCounter = new InterlockedCounter();

            for (int i = 0; i < PARALLELISM; ++i)
            {
                ThreadPool.QueueUserWorkItem(IncrementInterlockedCounterLotsOfTimes, globalCounter);
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Expected: {0}, actual: {1}", PARALLELISM * INCREMENTS, globalCounter.Current);
        }

        private static void IncrementInterlockedCounterLotsOfTimes(object obj)
        {
            InterlockedCounter counter = (InterlockedCounter)obj;
            for (int i = 0; i < INCREMENTS; ++i)
                counter.Next();
            Console.WriteLine("Completed");
        }

        /// <summary>
        /// Demonstrates how simple synchronization using the C# 'lock' statement
        /// protects the bank account object from having an incorrect account balance.
        /// </summary>
        private static void LockSynchronization()
        {
            BankAccount myAccount = new BankAccount();
            myAccount.Deposit(10000m);

            for (int i = 0; i < PARALLELISM; ++i)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    for (int k = 0; k < INCREMENTS; ++k)
                    {
                        myAccount.Deposit(10);
                        myAccount.Withdraw(10);
                    }
                });
            }

            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("Account balance: {0} (expected 10000)", myAccount.Balance);
        }

        /// <summary>
        /// Shows how a deadlock might ensue if resources are not locked in the same order.
        /// In this example, thread #1 acquires locks in the order c1, c2 and thread #2 
        /// acquires locks in the order c2, c1.  As a result, if sufficient time elapses,
        /// the threads are deadlocked because they are waiting for each other.  Detecting
        /// and resolving deadlocks is outside the scope of this demo, but one example strategy
        /// which prevents deadlocks such as this one is to perform lock ordering - always
        /// acquire locks in the same order.
        /// </summary>
        private static void Deadlocks()
        {
            Counter c1 = new Counter();
            Counter c2 = new Counter();

            ThreadPool.QueueUserWorkItem(delegate
            {
                lock (c1)
                {
                    Thread.Sleep(500);
                    for (int i = 0; i < 100000; ++i) c1.Next();
                    lock (c2)
                    {
                        for (int i = 0; i < 100000; ++i) c2.Next();
                    }
                }
                Console.WriteLine("Thread 1 done");
            });
            ThreadPool.QueueUserWorkItem(delegate
            {
                lock (c2)
                {
                    Thread.Sleep(500);
                    for (int i = 0; i < 100000; ++i) c2.Next();
                    lock (c1)
                    {
                        for (int i = 0; i < 100000; ++i) c1.Next();
                    }
                }
                Console.WriteLine("Thread 2 done");
            });
            Console.Write("Wait a few seconds for the threads to be done.  If nothing is printed, there's a deadlock");
            Console.ReadLine();
        }

        /// <summary>
        /// Demonstrates a simple producer-consumer scenario using a shared queue
        /// which internally uses Monitor.Pulse and Monitor.Wait to ensure that consumers
        /// blocked for input are woken up when input arrives from the producer.
        /// </summary>
        private static void PulseAndWait()
        {
            WorkQueue<int> queue = new WorkQueue<int>();
            Thread producer = new Thread(() =>
            {
                while (true)
                {
                    queue.Enqueue(42);
                    Thread.Sleep(10);
                }
            });
            Thread consumer = new Thread(() =>
            {
                while (true)
                {
                    queue.Dequeue();
                    Console.Write(".");
                }
            });
            producer.Start();
            consumer.Start();

            Console.ReadLine();
            producer.Abort(); consumer.Abort(); //Don't do this in a real application!
        }

        /// <summary>
        /// Demonstrates advanced synchronization features including the ManualResetEvent
        /// which is used here to receive a notification when a thread pool work item completes,
        /// and a "count-down event" implemented in the ParallelismExtensions.cs file which 
        /// allows parallel execution of multiple work items and waiting for them all to
        /// complete at once.
        /// </summary>
        private static void AdvancedSynchronization()
        {
            ManualResetEvent notify = new ManualResetEvent(false);
            Parallelism.DoAndLetMeKnow(delegate
            {
                Console.Write("In thread pool thread...");
                Thread.Sleep(2000);
                Console.WriteLine("...done!");
            }, notify);
            notify.WaitOne();
            Console.WriteLine("Main thread also thinks you're done.");

            Parallelism.DoInParallel(
                delegate { ThreadedConsole.WriteLine("Hi from action 1"); },
                delegate { ThreadedConsole.WriteLine("Hi from action 2"); },
                delegate { ThreadedConsole.WriteLine("Hi from action 3"); }
                );
        }
    }
}
