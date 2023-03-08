using System;
using UnityEngine;

public class TimeManager : MonoSigleton<TimeManager>
{
    private int m_GameSecond, m_GameMinute, m_GameHour;
    private int m_GameDay, m_GameMonth, m_GameYear;
    private int m_MonthInSeason = 3;
    private Season m_GameSeason;
    private bool m_GameTimePause;
    private float m_TikTime;

    private TimeSpan m_GameTime => new TimeSpan(m_GameHour, m_GameMinute, m_GameSecond);
    private float m_TimeDifference;

    protected override void Awake()
    {
        base.Awake();
        InitGameTime();
    }

    private void Start()
    {
        // EventHandler.CallGameMinuteEvent(m_GameMinute, m_GameHour, m_GameDay, m_GameSeason);
        EventCenter.BroadcastListener(EventType.EventGameMinute, m_GameMinute, m_GameHour, m_GameDay, m_GameSeason);
        EventHandler.CallGameDateEvent(m_GameHour, m_GameDay, m_GameMonth, m_GameYear, m_GameSeason);
        EventCenter.BroadcastListener(EventType.EventGameLight, m_GameSeason, GetLightType(), m_TimeDifference);
    }

    private void Update()
    {
        if (!m_GameTimePause)
        {
            m_TikTime += Time.deltaTime;
            if (m_TikTime >= Settings.secondThreshold)
            {
                m_TikTime -= Settings.secondThreshold;
                UpdateGameTime();
            }
        }

        // TODO: Delect
        if (Input.GetKey(KeyCode.T))
        {
            for (var i = 0; i < 60; i++)
            {
                UpdateGameTime();
            }
        }
    }

    private void InitGameTime()
    {
        m_GameSecond = 0;
        m_GameMinute = 0;
        m_GameHour = 16;
        m_GameDay = 1;
        m_GameMonth = 1;
        m_GameYear = 2023;
        m_GameSeason = Season.Spring;
    }

    private void UpdateGameTime()
    {
        m_GameSecond++;
        if (m_GameSecond > Settings.secondHold)
        {
            m_GameMinute++;
            m_GameSecond = 0;
            if (m_GameMinute > Settings.minuteHold)
            {
                m_GameHour++;
                m_GameMinute = 0;
                if (m_GameHour > Settings.hourHold)
                {
                    m_GameDay++;
                    m_GameHour = 0;
                    if (m_GameDay > Settings.dayHold)
                    {
                        m_GameDay = 1;
                        m_GameMonth++;
                        if (m_GameMonth > 12)
                        {
                            m_GameMonth = 1;
                        }

                        m_MonthInSeason--;
                        if (m_MonthInSeason == 0)
                        {
                            m_MonthInSeason = 3;
                            var seasonNumber = (int)m_GameSeason;
                            seasonNumber++;
                            if (seasonNumber > Settings.seasonHold)
                            {
                                seasonNumber = 0;
                                m_GameYear++;
                            }

                            m_GameSeason = (Season)seasonNumber;
                        }

                        // EventCenter.BroadcastListener(EventType.EventGameDay, m_GameDay, m_GameSeason);
                    }
                }

                EventHandler.CallGameDateEvent(m_GameHour, m_GameDay, m_GameMonth, m_GameYear, m_GameSeason);
            }

            // EventHandler.CallGameMinuteEvent(m_GameMinute, m_GameHour, m_GameDay, m_GameSeason);
            EventCenter.BroadcastListener(EventType.EventGameMinute, m_GameMinute, m_GameHour, m_GameDay, m_GameSeason);

            //Light
            EventCenter.BroadcastListener(EventType.EventGameLight, m_GameSeason, GetLightType(), m_TimeDifference);
        }
    }

    private LightType GetLightType()
    {
        if (m_GameTime >= Settings.morningTime && m_GameTime < Settings.nightTime)
        {
            m_TimeDifference = (float)(m_GameTime - Settings.morningTime).TotalMinutes;
            return LightType.Morning;
        }
        else if (m_GameTime < Settings.morningTime || m_GameTime >= Settings.nightTime)
        {
            m_TimeDifference = Mathf.Abs((float)(m_GameTime - Settings.nightTime).TotalMinutes);
            return LightType.Night;
        }
        else
        {
            return LightType.Morning;
        }
    }
}