using System;
using System.Threading;

namespace DelegatesAndEvents.AsyncDelegates
{
    /// <summary>
    /// Asynchronously invokes a multi-cast delegate.  Each handler
    /// in its invocation list is invoked separately in a completely
    /// asynchronous fashion.  Return values are not cached and are not
    /// returned, so delegates using this facility should not have a 
    /// return value.
    /// </summary>
    public sealed class AsyncInvoker
    {
        private readonly MulticastDelegate _del;

        public AsyncInvoker(MulticastDelegate del)
        {
            _del = del;
        }

        public void Invoke(params object[] args)
        {
            Delegate[] invocationList = _del.GetInvocationList();
            foreach (Delegate del in invocationList)
            {
                ThreadPool.QueueUserWorkItem(delegate { del.DynamicInvoke(args); });
            }
        }
    }

    /// <summary>
    /// Represents a type-safe event whose handlers are executed asynchronously
    /// when the event is raised.
    /// </summary>
    /// <typeparam name="TEventArgs">The event arguments type for this event.</typeparam>
    public sealed class AsyncEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        private EventHandler<TEventArgs> _handlers;

        public void AddHandler(EventHandler<TEventArgs> handler)
        {
            _handlers = (EventHandler<TEventArgs>)Delegate.Combine(_handlers, handler);
        }

        public void RemoveHandler(EventHandler<TEventArgs> handler)
        {
            _handlers = (EventHandler<TEventArgs>)Delegate.Remove(_handlers, handler);
        }

        public void Invoke(object sender, TEventArgs args)
        {
            AsyncInvoker invoker = new AsyncInvoker(_handlers);
            invoker.Invoke(sender, args);
        }
    }
}
