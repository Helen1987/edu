using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Win32;

namespace DelegatesAndEvents.SystemEventsFramework
{
    /// <summary>
    /// Hooks up an object to handle system events (using the Microsoft.Win32.SystemEvents class)
    /// by looking up attributes on the object's methods to detect which methods should be hooked
    /// up to which events.
    /// </summary>
    public static class EventHookup
    {
        /// <summary>
        /// Represents a pair of an event (represented by EventInfo) and a handler
        /// registered to the event.
        /// </summary>
        class EventDelegatePair
        {
            public EventInfo Event { get; set; }
            public Delegate Handler { get; set; }

            public EventDelegatePair(EventInfo @event, Delegate handler)
            {
                Event = @event;
                Handler = handler;
            }
        }

        private static Dictionary<object, List<EventDelegatePair>> _objectHandlers = new Dictionary<object, List<EventDelegatePair>>();

        /// <summary>
        /// Hooks up the object's methods marked with the [RegisterSystemEvent] attribute to the
        /// system event indicated by the attribute.  This demo shows how delegates can be 
        /// created at runtime using Delegate.CreateDelegate and how event registrations 
        /// can be performed dynamically at runtime using EventInfo.AddEventHandler.
        /// </summary>
        public static void HookupToSystemEvents(object @object)
        {
            if (@object == null)
                return;

            Type type = @object.GetType();
            foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                RegisterSystemEvent[] attrs = (RegisterSystemEvent[])
                    method.GetCustomAttributes(typeof(RegisterSystemEvent), false);

                foreach (RegisterSystemEvent attr in attrs)
                {
                    //The EventKind enum values are also the names of the individual events in the
                    //Microsoft.Win32.SystemEvents class.  By obtaining an EventInfo object, we can
                    //now register to the event dynamically.
                    EventInfo @event = typeof(SystemEvents).GetEvent(attr.EventKind.ToString());
                    if (@event == null)
                        continue;

                    //Create the handler delegate (to this object's method) and register it to the
                    //appropriate system event.
                    Delegate handler = Delegate.CreateDelegate(@event.EventHandlerType, @object, method);
                    @event.AddEventHandler(null, handler);  //SystemEvents is a static event source

                    lock (_objectHandlers)
                    {
                        List<EventDelegatePair> handlers;
                        if (!_objectHandlers.TryGetValue(@object, out handlers))
                        {
                            handlers = new List<EventDelegatePair>();
                            _objectHandlers.Add(@object, handlers);
                        }
                        handlers.Add(new EventDelegatePair(@event, handler));
                    }
                }
            }
        }

        /// <summary>
        /// Unhooks the object's methods marked with the [RegisterSystemEvent] attribute from the
        /// system event indicated by the attribute.  This demo shows how event unregistrations 
        /// can be performed dynamically at runtime using EventInfo.RemoveEventHandler.
        /// </summary>
        public static void UnhookFromSystemEvents(object @object)
        {
            if (@object == null)
                return;

            lock (_objectHandlers)
            {
                List<EventDelegatePair> handlers;
                if (!_objectHandlers.TryGetValue(@object, out handlers))
                    return;

                handlers.ForEach(pair => pair.Event.RemoveEventHandler(null, pair.Handler));
            }
        }
    }
}
