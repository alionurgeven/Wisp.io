using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    // Dictionary for the events that hold event names and corresponding events
    private Dictionary<string, UnityEvent> events;

    /// <summary>
    /// Adds a given listener to the event with the event name for future triggering
    /// </summary>
    /// <param name="eventName">Name of the event</param>
    /// <param name="listener">Name of the listener to add</param>
    public void StartListening(string eventName, UnityAction listener)
    {
        // New event for the given event name
        UnityEvent thisEvent = null;

        // If the event name already exists ...
        if (events.TryGetValue(eventName, out thisEvent))
        {
            // ... add listener to the existing event
            thisEvent.AddListener(listener);
        }
        else
        {
            // ... create new event and add the listener.
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            events.Add(eventName, thisEvent);
        }
    }

    /// <summary>
    /// Remove the given listener from the given event with the event name
    /// </summary>
    /// <param name="eventName">Name of the event</param>
    /// <param name="listener">Name of the listener to remove</param>
    public void StopListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;

        // If the event name exists ...
        if (events.TryGetValue(eventName, out thisEvent))
        {
            // ... remove the listener from the event.
            thisEvent.RemoveListener(listener);
        }
    }

    /// <summary>
    /// Trigger the event with the given name
    /// </summary>
    /// <param name="eventName">Name of the event to trigger</param>
    public void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;

        // If the event name exists ...
        if (events.TryGetValue(eventName, out thisEvent))
        {
            // ... invoke the listeners of the event.
            thisEvent.Invoke();
        }
    }
}
