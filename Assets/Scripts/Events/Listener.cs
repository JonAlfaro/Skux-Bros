using System;
using UnityEngine;
using EventType = Constants.EventType;
/*
 * Creates a Unity gameObject attached to a parent gameObject.
 * Subscribes a method to an event and will automatically handle subscription/unsubscription when needed.
 *
 * Unsubscription happens when the GameObject is disabled or destroyed. If enabled, it will automatically subscribe again.
 * When the parent gameObject is disabled/enabled/destroyed, this object will be affected as well.
 *
 * Create using the ListenerCreation helper class
 */
public class Listener : MonoBehaviour
{
    private Action<object, EventArgs> eventListener;
    private EventType currentEventType;

    // Creates an object subscribed to an event. This subscription automatically handled when parent is enabled/disabled/destroyed.
    public static Listener CreateListener(Transform parent, Action<object, EventArgs> action, EventType eventType)
    {
        GameObject go = new GameObject("__eventListener", typeof(Listener));
        go.transform.parent = parent;

        Listener listener = go.GetComponent<Listener>();

        listener.StartListening(action, eventType);

        return listener;
    }

    // Starts listening to this action. Will override any previous action, unsubscribing it in the process
    public void StartListening(Action<object, EventArgs> action, EventType eventType)
    {
        eventListener?.Unsubscribe(currentEventType); // Unsubscribe if we already have an event

        eventListener = action;
        currentEventType = eventType;

        name = $"__eventListener ({eventType.ToString()})"; // Set gameObject.name

        eventListener.Subscribe(eventType);
    }

    private void OnDisable()
    {
        eventListener?.Unsubscribe(currentEventType);
    }

    private void OnEnable()
    {
        eventListener?.Subscribe(currentEventType);
    }
}