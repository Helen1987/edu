using System;
using System.Threading;

namespace GC_Notifications
{
    /// <summary>
    /// Demonstrates the use of the .NET 3.5 SP1 garbage collection notifications.
    /// This class spawns a separate thread which listens for garbage collection
    /// notifications and raises events when a GC approaches and when a GC completes.
    /// 
    /// The app.config file contains a configuration directive which instructs the
    /// runtime to use workstation non-concurrent GC, because the GC notifications
    /// API does not work if concurrent GC is enabled.
    /// 
    /// Note that the use of Thread.Abort to terminate a thread is not generally
    /// recommended, and is used here for expository purposes only.
    /// </summary>
    class GCNotifications
    {
        private Thread _thread;

        public event EventHandler GCApproaches;
        public event EventHandler GCCompleted;

        public GCNotifications()
        {
            _thread = new Thread(Loop);
            _thread.Start();
        }

        public void Stop()
        {
            _thread.Abort();
        }

        private void Loop()
        {
            GC.RegisterForFullGCNotification(10, 10);
            while (true)
            {
                GCNotificationStatus status = GC.WaitForFullGCApproach();
                if (status == GCNotificationStatus.Succeeded)
                {
                    if (GCApproaches != null) { GCApproaches(this, EventArgs.Empty); }
                    status = GC.WaitForFullGCComplete();
                    if (status == GCNotificationStatus.Succeeded)
                    {
                        if (GCCompleted != null) { GCCompleted(this, EventArgs.Empty); }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        static void Main(string[] args)
        {
            GCNotifications notifier = new GCNotifications();
			notifier.GCApproaches += delegate { Console.WriteLine("GC approaches"); Console.WriteLine(GC.GetTotalMemory(false)); };
			notifier.GCCompleted += delegate { Console.WriteLine("GC completed"); Console.WriteLine(GC.GetTotalMemory(false)); };

            //Allocate memory so that we actually trigger GC
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(10);
                byte[] dummy = new byte[100000];
            }
        }
    }
}
