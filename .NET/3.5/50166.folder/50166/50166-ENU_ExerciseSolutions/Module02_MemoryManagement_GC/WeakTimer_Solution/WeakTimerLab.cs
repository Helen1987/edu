using System;
using System.Threading;

namespace WeakTimer_Solution
{
    /// <summary>
    /// Represents an object registering for a timer notification.
    /// </summary>
    public interface ITimerElapsed
    {
        /// <summary>
        /// Invoked when the timer has elapsed.
        /// </summary>
        void Elapsed();
    }
    
    /// <summary>
    /// Stores a weak reference to the registered object and invokes
    /// the Elapsed method if the object has not been garbage collected.
    /// If it were, the timer is automatically cancelled.
    /// </summary>
    public class WeakTimer
    {
        private Timer _timer;
        private WeakReference _client;

        public WeakTimer(int interval, ITimerElapsed timer)
        {
            _timer = new Timer(OnTimer, null, 0, interval);
            _client = new WeakReference(timer);
        }

        public void Cancel()
        {
            _timer.Dispose();
        }

        private void OnTimer(object state)
        {
            ITimerElapsed timerElapsed = (ITimerElapsed)_client.Target;
            if (timerElapsed == null)
            {
                Cancel();
            }
            else
            {
                timerElapsed.Elapsed();
            }
        }
    }

    /// <summary>
    /// Demonstrates sample use of the weak-reference-based timer.
    /// Run in Release mode to see the registered object being freed
    /// after the last instruction where it is used.
    /// </summary>
    class WeakTimerLab
    {
        class RegisteredObject : ITimerElapsed
        {
            public void Elapsed()
            {
                Console.WriteLine("Timer elapsed");
            }
        }

        /// <summary>
        /// Expected behavior: before the first Console.ReadLine returns,
        /// the timer is continuously invoked every second.
        /// After the first Console.ReadLine returns, the timer is no
        /// longer invoked (because its "target" is garbage collected).
        /// </summary>
        static void Main(string[] args)
        {
            RegisteredObject registeredObject = new RegisteredObject();
            WeakTimer timer = new WeakTimer(1000, registeredObject);

            GC.Collect();
            Console.ReadLine();

            GC.KeepAlive(registeredObject);

            GC.Collect();
            Console.ReadLine();
        }
    }
}
