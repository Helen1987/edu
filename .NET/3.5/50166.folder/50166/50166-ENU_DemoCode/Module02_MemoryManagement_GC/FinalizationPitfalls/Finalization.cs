using System;
using System.Threading;

namespace FinalizationPitfalls
{
    /// <summary>
    /// All the demos in this section should be run in Release mode, to ensure
    /// that the garbage collector collects local references as soon as they
    /// are no longer used.
    /// </summary>
    class Finalization
    {
        /// <summary>
        /// Uncomment one line at a time to see a demonstration of the various
        /// scenarios - race condition, deadlock and memory leak - when using
        /// non-deterministic finalization.
        /// </summary>
        static void Main(string[] args)
        {
            //MemoryLeak();
            //Deadlock();
            RaceCondition();
        }

        /// <summary>
        /// Causes a race condition by performing a time consuming operation,
        /// while in the meantime the object itself is marked for finalization
        /// and its finalizer closes the handle which is subsequently used
        /// by the operation.
        /// </summary>
        private static void RaceCondition()
        {
            Resource3 resource = new Resource3();
            resource.Work();
        }

        /// <summary>
        /// Simulates a deadlock by acquiring a lock and waiting for the
        /// finalizer to complete while at the same time the finalizer requires
        /// the same lock.  The main application thread and the finalizer
        /// thread enter a deadly embrace.
        /// </summary>
        private static void Deadlock()
        {
            lock (typeof(Resource2))
            {
                new Resource2();    //Create and immediately destroy
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// Leaks memory by creating objects at a faster rate than they can
        /// be finalized.  The Resource1 constructor takes 10ms but its finalizer
        /// takes 20ms, producing a steady memory leak.
        /// </summary>
        private static void MemoryLeak()
        {
            for (int i = 1; !Console.KeyAvailable; ++i)
            {
                new Resource1(); //Create and immediately destroy

                if (i % 100 == 0)
                    Console.WriteLine((GC.GetTotalMemory(false) / 1024) + " KB managed memory in use");
            }
        }
    }

    /// <summary>
    /// Demonstrates the memory leak scenario.
    /// </summary>
    class Resource1
    {
        private byte[] _data = new byte[16384];

        public Resource1()
        {
            Thread.Sleep(10);
        }

        ~Resource1()
        {
            Thread.Sleep(20);
        }
    }

    /// <summary>
    /// Demonstrates the deadlock scenario.
    /// </summary>
    class Resource2
    {
        ~Resource2()
        {
            lock (typeof(Resource2))
            {
            }
        }
    }

    /// <summary>
    /// Demonstrates the race condition scenario.
    /// </summary>
    class Resource3
    {
        /// <summary>
        /// Represents a handle for demonstration purposes.  For example,
        /// this could be an operating system handle.
        /// 
        /// In this specific scenario, an OS handle would behave in an even
        /// less predictable way than this simulation handle which simply
        /// throws an ObjectDisposedException exception when used after
        /// being closed.  An OS handle can be recycled, meaning that after
        /// it was closed the same handle value can be assigned to a completely
        /// different object, which would then be erroneously used by the
        /// application instead of the object intended.  This is a much more
        /// subtle bug to find.
        /// </summary>
        class Handle
        {
            private bool _closed;

            public void Close() { _closed = true; }
            public void Use()
            {
                if (_closed) throw new ObjectDisposedException("handle");
            }
        }

        private Handle _handle = new Handle();

        /// <summary>
        /// Caches a local copy of the handle and then waits for the
        /// finalizer to run, destroying the handle.
        /// 
        /// The safest way to defend against this scenario is by adding
        /// the following line as the last line of this method:
        /// 
        ///     GC.KeepAlive(this);
        ///     
        /// This line would prevent the object from being finalized.
        /// </summary>
        public void Work()
        {
            Handle h = _handle;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            h.Use();
        }

        ~Resource3()
        {
            _handle.Close();
        }
    }
}
