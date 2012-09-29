using System.Collections.Generic;
using System.Threading;

namespace Synchronization
{
    /// <summary>
    /// A thread-safe queue of items.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    class WorkQueue<T> : Queue<T>
    {
        private readonly object _syncRoot = new object();

        public new void Enqueue(T item)
        {
            Monitor.Enter(_syncRoot);
            try
            {
                base.Enqueue(item);
                //Let consumers know that there are items to be consumed in the queue.
                Monitor.Pulse(_syncRoot);
            }
            finally
            {
                Monitor.Exit(_syncRoot);
            }
        }

        public new T Dequeue()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                while (base.Count == 0)
                    Monitor.Wait(_syncRoot);
                //It's now safe to call Dequeue because when the call to Wait
                //returns, we own the lock (it has already been released by the caller).
                return base.Dequeue();
            }
            finally
            {
                Monitor.Exit(_syncRoot);
            }
        }
    }
}
