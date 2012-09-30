﻿using System.Collections.Generic;
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
            //TODO: Implement this method, making sure the queue is synchronized
            //against concurrent access.
        }

        /// <summary>
        /// Dequeues an item from the queue, waiting if no items
        /// are currently available.
        /// </summary>
        /// <returns>The dequeued item.</returns>
        public T Dequeue()
        {
            return default(T);

            //TODO: Implement this method, making sure the queue is synchronized
            //against concurrent access.  Note that this method should return only
            //after an item has been dequeued, so it might have to wait.
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