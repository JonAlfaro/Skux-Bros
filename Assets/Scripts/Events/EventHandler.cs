using System;
using System.Collections.Generic;
using EventType = Constants.EventType;

/*
 * Generic event handler. Stores events in a dictionary and invokes them when Invoke() is called.
 * Subscribe a function to an EventType and when Invoke() is called with that EventType, the function will be called.
 *
 * Remember to Unsubscribe() before an object is destroyed.
 * Remember to keep a reference to the listener if you need to unsubscribe at some point.
 */
public static class EventHandler
{
    private static readonly Dictionary<EventType, Action<object, EventArgs>> EventDictionary = new Dictionary<EventType, Action<object, EventArgs>>();

    public static void Subscribe(this Action<object, EventArgs> listener, EventType eventTypeType)
    {
        if (EventDictionary.TryGetValue(eventTypeType, out var thisEvent))
        {
            thisEvent += listener;
            EventDictionary[eventTypeType] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            EventDictionary.Add(eventTypeType, thisEvent);
        }
    }

    public static void Unsubscribe(this Action<object, EventArgs> listener, EventType eventTypeType)
    {
        if (EventDictionary.TryGetValue(eventTypeType, out var thisEvent))
        {
            thisEvent -= listener;
            if (thisEvent == null) EventDictionary.Remove(eventTypeType);
            else EventDictionary[eventTypeType] = thisEvent;
        }
    }

    public static void Invoke(EventType eventTypeType, object sender = null, EventArgs e = null)
    {
        if (EventDictionary.TryGetValue(eventTypeType, out var thisEvent))
        {
            thisEvent.Invoke(sender, e);
        }
    }
}