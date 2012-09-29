using System.Threading;

namespace QueuingWork
{
    /// <summary>
    /// An event which is signaled after it has been set for the specified
    /// number of times.  It is somewhat similar to a "reversed" semaphore.
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
}
