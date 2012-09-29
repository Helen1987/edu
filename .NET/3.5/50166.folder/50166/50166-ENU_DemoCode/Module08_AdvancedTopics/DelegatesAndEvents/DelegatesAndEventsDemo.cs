using System;
using System.Threading;
using DelegatesAndEvents.AsyncDelegates;
using DelegatesAndEvents.LoggingFramework;
using DelegatesAndEvents.SystemEventsFramework;

namespace DelegatesAndEvents
{
    /// <summary>
    /// A demo of the [LogMethod] and [RegisterSystemEvent] attributes.
    /// </summary>
    class Box
    {
        public string Name { get; set; }
        public decimal Volume { get; set; }

        /// <summary>
        /// Invoked when a log-friendly representation of this instance
        /// is requested by the DynamicLogger class.
        /// </summary>
        [LogMethod]
        private string Log()
        {
            return Name + " contains " + Volume;
        }

        /// <summary>
        /// Invoked when the system display settings change.  To cause this
        /// method to be invoked, change the resolution of the display (or any
        /// other display setting).
        /// </summary>
        [RegisterSystemEvent(SystemEventKind.DisplaySettingsChanged)]
        private void DisplayChanged(object sender, EventArgs args)
        {
            Console.WriteLine("Display settings changed");
        }
    }

    /// <summary>
    /// Demonstrates advanced delegates and events features, including dynamically
    /// binding to delegates at runtime, dynamically registering to and unregistering
    /// from events and asynchronously invoking delegates and events.
    /// </summary>
    class DelegatesAndEventsDemo
    {
        static void Main(string[] args)
        {
            DynamicDelegatesDemo();
            DynamicEventsDemo();
            AsyncEventsDemo();

            Console.WriteLine("Press RETURN to exit the demo.");
            Console.ReadLine();
        }

        /// <summary>
        /// In this demo, the dynamic logger framework is used to invoke
        /// the log method of the Box class through a dynamic delegate.
        /// </summary>
        private static void DynamicDelegatesDemo()
        {
            Box box = new Box { Name = "Chips", Volume = 2.0m };
            DynamicLogger.Log(Console.Out, box);
        }

        /// <summary>
        /// In this demo, the Box class is wired up to the Microsoft.Win32.SystemEvents.DisplaySettingsChanged
        /// event, which is invoked when the display settings are changed.
        /// </summary>
        private static void DynamicEventsDemo()
        {
            Box box = new Box { Name = "Chips", Volume = 2.0m };
            EventHookup.HookupToSystemEvents(box);

            Console.WriteLine("Change the display properties please.");
            Console.ReadLine();

            EventHookup.UnhookFromSystemEvents(box);
        }

        /// <summary>
        /// In this demo, the handlers are invoked asynchronously on different threads,
        /// none of them being the main thread which caused the event invocation.
        /// </summary>
        private static void AsyncEventsDemo()
        {
            EventHandler<EventArgs> handler1 = delegate { Console.WriteLine("Handler 1 in thread " + Thread.CurrentThread.ManagedThreadId); };
            EventHandler<EventArgs> handler2 = delegate { Console.WriteLine("Handler 2 in thread " + Thread.CurrentThread.ManagedThreadId); };

            AsyncEventSource.Register(handler1);
            AsyncEventSource.Register(handler2);

            AsyncEventSource.Invoke();

            AsyncEventSource.Unregister(handler1);
            AsyncEventSource.Unregister(handler2);
        }
    }
}
