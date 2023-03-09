using UnityEngine;

public class LightManager : MonoBehaviour
{
    private LightController[] m_LightControllers;
    private Season m_Season;
    private LightType m_LightType = LightType.Night;
    private float m_TimeDifference;

    private void Awake()
    {
        EventHandler.GameSceneLoadEvent += OnGameSceneLoadEvent;
        EventCenter.AddListener<Season, LightType, float>(EventType.EventGameLight, OnGameLightEvent);
        m_LightType = Settings.startLightType;
    }

    private void OnGameSceneLoadEvent()
    {
        m_LightControllers = FindObjectsOfType<LightController>();
        foreach (var lightController in m_LightControllers)
        {
            lightController.SwitchLight(m_Season, m_LightType, m_TimeDifference);
        }
    }

    private void OnGameLightEvent(Season season, LightType lightType, float timeDifference)
    {
        m_Season = season;
        m_TimeDifference = timeDifference;
        if (m_LightType != lightType)
        {
            m_LightType = lightType;
            foreach (var lightController in m_LightControllers)
            {
                lightController.SwitchLight(m_Season, m_LightType, m_TimeDifference);
            }
        }
    }

    private void OnDestroy()
    {
        EventHandler.GameSceneLoadEvent -= OnGameSceneLoadEvent;
        EventCenter.RemoveListener<Season, LightType, float>(EventType.EventGameLight, OnGameLightEvent);
    }
}