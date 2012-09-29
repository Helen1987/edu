using System;
using System.Collections.Generic;
using System.Threading;

namespace QueuingWork
{
    /// <summary>
    /// A thread-safe queue of items.
    /// </summary>
    /// <typeparam name="T">The type of the items.</typeparam>
    public sealed class ThreadSafeQueue<T>
    {
        private readonly object _syncRoot = new object();
        private readonly Queue<T> _queue = new Queue<T>();

        /// <summary>
        /// Enqueues an item into the queue.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        public void Enqueue(T item)
        {
            Monitor.Enter(_syncRoot);
            try
            {
                _queue.Enqueue(item);
                Monitor.Pulse(_syncRoot);
            }
            finally
            {
                Monitor.Exit(_syncRoot);
            }
        }

        /// <summary>
        /// Dequeues an item from the queue, waiting if no items
        /// are currently available.
        /// </summary>
        /// <returns>The dequeued item.</returns>
        public T Dequeue()
        {
            Monitor.Enter(_syncRoot);
            try
            {
                while (_queue.Count == 0)
                    Monitor.Wait(_syncRoot);
                //It's now safe to call Dequeue because when the call to Wait
                //returns, we own the lock (it has already been released by the caller).
                return _queue.Dequeue();
            }
            finally
            {
                Monitor.Exit(_syncRoot);
            }
        }

        /// <summary>
        /// Retrieves all the items from the queue in array form.
        /// This method performs no synchronization and therefore should
        /// be called ONLY if no concurrent access to the queue is possible.
        /// </summary>
        public T[] UnsafeItems
        {
            get { return _queue.ToArray(); }
        }
    }
}
