/// <summary>
/// EventType
/// </summary>
public enum EventType
{
    /* Example
     * EventType.EventName
     * Awake() EventCenter.AddListener(EventType.EventName, Function());
     * OnDestroy() EventCenter.RemoveListener(EventType.EventName, Function());
     * EventCenter.BroadcastListener(EventType.EventName);
     */
    EventName = 0,
    EventGameMinute,
    EventGameLight,
}