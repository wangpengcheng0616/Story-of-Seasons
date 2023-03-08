using System;
using System.Collections.Generic;

public class EventCenter
{
    /// <summary>
    /// EventDictionary
    /// </summary>
    private static Dictionary<EventType, Delegate> m_EventDictionary = new Dictionary<EventType, Delegate>();

    /// <summary>
    /// OnListenerAdding
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <exception cref="Exception"></exception>
    private static void OnListenerAdding(EventType eventType, Delegate eventCallBack)
    {
        if (!m_EventDictionary.ContainsKey(eventType))
        {
            m_EventDictionary.Add(eventType, null);
        }

        Delegate d = m_EventDictionary[eventType];
        if (!ReferenceEquals(d, null) && d.GetType() != eventCallBack.GetType())
        {
            throw new Exception(
                $"Try to add different types of delegates for {eventType},current type of delegate is {d.GetType()},the delegate type to be added is {eventCallBack.GetType()}"
            );
        }
    }

    /// <summary>
    /// AddListener
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    public static void AddListener(EventType eventType, EventCallBack eventCallBack)
    {
        OnListenerAdding(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack)m_EventDictionary[eventType] + eventCallBack;
    }

    /// <summary>
    /// AddListener<T>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T"></typeparam>
    public static void AddListener<T>(EventType eventType, EventCallBack<T> eventCallBack)
    {
        OnListenerAdding(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T>)m_EventDictionary[eventType] + eventCallBack;
    }

    /// <summary>
    /// AddListener<T1, T2>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public static void AddListener<T1, T2>(EventType eventType, EventCallBack<T1, T2> eventCallBack)
    {
        OnListenerAdding(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T1, T2>)m_EventDictionary[eventType] + eventCallBack;
    }

    /// <summary>
    /// AddListener<T1, T2, T3>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public static void AddListener<T1, T2, T3>(EventType eventType, EventCallBack<T1, T2, T3> eventCallBack)
    {
        OnListenerAdding(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T1, T2, T3>)m_EventDictionary[eventType] + eventCallBack;
    }

    /// <summary>
    /// AddListener<T1, T2, T3, T4>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public static void AddListener<T1, T2, T3, T4>(EventType eventType, EventCallBack<T1, T2, T3, T4> eventCallBack)
    {
        OnListenerAdding(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T1, T2, T3, T4>)m_EventDictionary[eventType] + eventCallBack;
    }

    /// <summary>
    /// OnListenerRemoving
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <exception cref="Exception"></exception>
    private static void OnListenerRemoving(EventType eventType, Delegate eventCallBack)
    {
        if (m_EventDictionary.ContainsKey(eventType))
        {
            Delegate d = m_EventDictionary[eventType];
            if (ReferenceEquals(d, null))
            {
                throw new Exception($"Remove Listener Error, the {eventType} has no corresponding delegate");
            }
            else if (d.GetType() != eventCallBack.GetType())
            {
                throw new Exception(
                    $"Remove Listener Error,try to add different types of delegates for {eventType},current type of delegate is {d.GetType()},the delegate type to be added is {eventCallBack.GetType()}");
            }
        }
        else
        {
            throw new Exception($"Remove Listener Error, no event code {eventType}");
        }
    }

    /// <summary>
    /// OnListenerRemoved
    /// </summary>
    /// <param name="eventType"></param>
    private static void OnListenerRemoved(EventType eventType)
    {
        if (ReferenceEquals(m_EventDictionary[eventType], null))
        {
            m_EventDictionary.Remove(eventType);
        }
    }

    /// <summary>
    /// RemoveListener
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    public static void RemoveListener(EventType eventType, EventCallBack eventCallBack)
    {
        OnListenerRemoving(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack)m_EventDictionary[eventType] - eventCallBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// RemoveListener<T>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T"></typeparam>
    public static void RemoveListener<T>(EventType eventType, EventCallBack<T> eventCallBack)
    {
        OnListenerRemoving(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T>)m_EventDictionary[eventType] - eventCallBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// RemoveListener<T1, T2>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public static void RemoveListener<T1, T2>(EventType eventType, EventCallBack<T1, T2> eventCallBack)
    {
        OnListenerRemoving(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T1, T2>)m_EventDictionary[eventType] - eventCallBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// RemoveListener<T1, T2, T3>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public static void RemoveListener<T1, T2, T3>(EventType eventType, EventCallBack<T1, T2, T3> eventCallBack)
    {
        OnListenerRemoving(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T1, T2, T3>)m_EventDictionary[eventType] - eventCallBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// RemoveListener<T1, T2, T3, T4>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="eventCallBack"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public static void RemoveListener<T1, T2, T3, T4>(EventType eventType, EventCallBack<T1, T2, T3, T4> eventCallBack)
    {
        OnListenerRemoving(eventType, eventCallBack);
        m_EventDictionary[eventType] = (EventCallBack<T1, T2, T3, T4>)m_EventDictionary[eventType] - eventCallBack;
        OnListenerRemoved(eventType);
    }

    /// <summary>
    /// BroadcastListener
    /// </summary>
    /// <param name="eventType"></param>
    /// <exception cref="Exception"></exception>
    public static void BroadcastListener(EventType eventType)
    {
        Delegate d;
        if (m_EventDictionary.TryGetValue(eventType, out d))
        {
            EventCallBack eventCallBack = d as EventCallBack;
            if (!ReferenceEquals(eventCallBack, null))
            {
                eventCallBack();
            }
            else
            {
                throw new Exception($"Broadcast Listener Error,{eventType} has different types of delegates");
            }
        }
    }

    /// <summary>
    /// BroadcastListener<T>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="arg"></param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="Exception"></exception>
    public static void BroadcastListener<T>(EventType eventType, T arg)
    {
        Delegate d;
        if (m_EventDictionary.TryGetValue(eventType, out d))
        {
            EventCallBack<T> eventCallBack = d as EventCallBack<T>;
            if (!ReferenceEquals(eventCallBack, null))
            {
                eventCallBack(arg);
            }
            else
            {
                throw new Exception($"Broadcast Listener Error,{eventType} has different types of delegates");
            }
        }
    }

    /// <summary>
    /// BroadcastListener<T1, T2>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <exception cref="Exception"></exception>
    public static void BroadcastListener<T1, T2>(EventType eventType, T1 arg1, T2 arg2)
    {
        Delegate d;
        if (m_EventDictionary.TryGetValue(eventType, out d))
        {
            EventCallBack<T1, T2> eventCallBack = d as EventCallBack<T1, T2>;
            if (!ReferenceEquals(eventCallBack, null))
            {
                eventCallBack(arg1, arg2);
            }
            else
            {
                throw new Exception($"Broadcast Listener Error,{eventType} has different types of delegates");
            }
        }
    }

    /// <summary>
    /// BroadcastListener<T1, T2, T3>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <exception cref="Exception"></exception>
    public static void BroadcastListener<T1, T2, T3>(EventType eventType, T1 arg1, T2 arg2, T3 arg3)
    {
        Delegate d;
        if (m_EventDictionary.TryGetValue(eventType, out d))
        {
            EventCallBack<T1, T2, T3> eventCallBack = d as EventCallBack<T1, T2, T3>;
            if (!ReferenceEquals(eventCallBack, null))
            {
                eventCallBack(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception($"Broadcast Listener Error,{eventType} has different types of delegates");
            }
        }
    }

    /// <summary>
    /// BroadcastListener<T1, T2, T3, T4>
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <param name="arg4"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <exception cref="Exception"></exception>
    public static void BroadcastListener<T1, T2, T3, T4>(EventType eventType, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        Delegate d;
        if (m_EventDictionary.TryGetValue(eventType, out d))
        {
            EventCallBack<T1, T2, T3, T4> eventCallBack = d as EventCallBack<T1, T2, T3, T4>;
            if (!ReferenceEquals(eventCallBack, null))
            {
                eventCallBack(arg1, arg2, arg3, arg4);
            }
            else
            {
                throw new Exception($"Broadcast Listener Error,{eventType} has different types of delegates");
            }
        }
    }
}