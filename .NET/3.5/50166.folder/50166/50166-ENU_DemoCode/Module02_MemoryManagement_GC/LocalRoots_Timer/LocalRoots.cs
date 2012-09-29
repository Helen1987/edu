using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace LocalRoots_Timer
{
    /// <summary>
    /// Running this application in the Debug build results in the predictable
    /// output every second as the timer is invoked.  Running it in the Release
    /// build outputs only a single time and then the timer stops.
    /// 
    /// This is caused by the fact the GC in Release mode knows that the timer
    /// local reference is no longer in use on the main thread when the current
    /// Console.ReadLine statement is executing.  Therefore, it can be freed
    /// after the collection, terminating the timer.
    /// 
    /// This is fairly unexpected behavior, and does not happen for every flavor
    /// of a .NET timer, not even for every constructor of the System.Threading
    /// timer.  However, it demonstrates fairly well the problem with local roots
    /// being scoped to their last place of use.
    /// 
    /// Correcting this program requires adding the following line after the
    /// Console.ReadLine call:
    /// 
    ///     GC.KeepAlive(timer);
    ///     
    /// The MyGCKeepAlive method below is also a feasible alternative for the
    /// GC.KeepAlive call - it is a non-inlined method that does nothing, but
    /// by its very existence extends the lifetime of its parameter.
    /// </summary>
    class LocalRoots
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(OnTimer, null, 1000, 1000);
            Console.ReadLine();
        }

        private static void OnTimer(object dummy)
        {
            Console.WriteLine(DateTime.Now.TimeOfDay);
            GC.Collect();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void MyKeepAlive(object dummy)
        {
        }
    }
}
