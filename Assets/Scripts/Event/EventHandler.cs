using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<int, int> GameMinuteEvent;

    public static void CallGameMinuteEvent(int minute, int hour)
    {
        GameMinuteEvent?.Invoke(minute, hour);
    }

    public static event Action<int, int, int, int, Season> GameDateEvent;

    public static void CallGameDateEvent(int hour, int day, int month, int year, Season season)
    {
        GameDateEvent?.Invoke(hour, day, month, year, season);
    }

    public static event Action<string, Vector3> GameTransferEvent;

    public static void CallGameTransferEvent(string sceneName, Vector3 scenePosition)
    {
        GameTransferEvent?.Invoke(sceneName, scenePosition);
    }

    public static event Action GameSceneUnloadEvent;

    public static void CallGameSceneUnloadEvent()
    {
        GameSceneUnloadEvent?.Invoke();
    }


    public static event Action GameSceneLoadEvent;

    public static void CallGameSceneLoadEvent()
    {
        GameSceneLoadEvent?.Invoke();
    }

    public static event Action<Vector3> GameMoveToPositionEvent;

    public static void CallGameMoveToPositionEvent(Vector3 position)
    {
        GameMoveToPositionEvent?.Invoke(position);
    }

    public static event Action<float> GameUILoadingEvent;

    public static void CallGameUILoadingEvent(float alpha)
    {
        GameUILoadingEvent?.Invoke(alpha);
    }
}