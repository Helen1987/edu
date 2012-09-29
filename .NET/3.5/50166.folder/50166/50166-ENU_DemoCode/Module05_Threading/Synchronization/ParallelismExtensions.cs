using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Synchronization
{
    /// <summary>
    /// Extensions which facilitate parallelizing sets of work.
    /// </summary>
    static class Parallelism
    {
        /// <summary>
        /// Performs work asynchronously and sets the specified event handle
        /// when it is done.
        /// </summary>
        /// <param name="action">The work to perform.</param>
        /// <param name="event">The event to set.</param>
        public static void DoAndLetMeKnow(Action action, EventWaitHandle @event)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                action();
                @event.Set();
            });
        }

        /// <summary>
        /// Performs multiple actions in parallel and returns when all actions are done.
        /// </summary>
        /// <param name="actions">The actions to perform in parallel.</param>
        public static void DoInParallel(params Action[] actions)
        {
            CountdownEvent counter = new CountdownEvent(actions.Length);
            foreach (Action action in actions)
            {
                Action copy = action;   //Prevent late capturing
                ThreadPool.QueueUserWorkItem(delegate { copy(); counter.Set(); });
            }
            counter.Wait();
        }

        /// <summary>
        /// Performs work in parallel for each element in the enumerable, does not guarantee
        /// order of execution within the enumerable.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="coll">The collection of elements.</param>
        /// <param name="action">The action to perform in parallel for each element.</param>
        public static void ParallelForEach<T>(this IEnumerable<T> coll, Action<T> action)
        {
            //This is quite close (API-wise) to the Parallel.ForEach that ships in the Parallel Extensions
            //for .NET.  However, this version is highly inefficient because it performs very stupid scheduling
            //and uses the thread pool.  It works well only for very bulky collections of work.

            DoInParallel((from item in coll
                          let c = item
                          select new Action(() => action(c))).ToArray());
        }
    }

    /// <summary>
    /// An event that becomes signaled after it is set for the specified number
    /// of times.  This resembles a "reverse" semaphore.
    /// </summary>
    class CountdownEvent
    {
        private int _count;
        private ManualResetEvent _done = new ManualResetEvent(false);

        public CountdownEvent(int count) { _count = count; }

        public void Set()
        {
            if (Interlocked.Decrement(ref _count) == 0)
                _done.Set();
        }

        public void Wait()
        {
            _done.WaitOne();
        }
    }

    static class ThreadedConsole
    {
        public static void WriteLine(string s)
        {
            Console.WriteLine("[~{0}] {1}", Thread.CurrentThread.ManagedThreadId, s);
        }
    }
}
