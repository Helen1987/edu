using System;

namespace DelegatesAndEvents.AsyncDelegates
{
    /// <summary>
    /// A sample event source for the asynchronous event framework.  This class exposes
    /// an event along with registration, unregistration and invocation facilities.  While it 
    /// does not use the C# language syntax for events, it is still fairly convenient to use.
    /// When the event is raised, its handlers are invoked asynchronously.
    /// </summary>
    public static class AsyncEventSource
    {
        private static AsyncEventHandler<EventArgs> _event = new AsyncEventHandler<EventArgs>();

        public static void Register(EventHandler<EventArgs> handler)
        {
            _event.AddHandler(handler);
        }

        public static void Unregister(EventHandler<EventArgs> handler)
        {
            _event.RemoveHandler(handler);
        }

        public static void Invoke()
        {
            _event.Invoke(null, EventArgs.Empty);
        }
    }
}
