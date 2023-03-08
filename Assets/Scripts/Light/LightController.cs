using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] private LightData m_LightData;
    private Light2D m_Light2D;
    private LightProperties m_LightProperties;

    private void Awake()
    {
        m_Light2D = GetComponent<Light2D>();
    }

    public void SwitchLight(Season season, LightType lightType, float timeDifference)
    {
        m_LightProperties = m_LightData.GetLightProperties(season, lightType);
        if (timeDifference < Settings.lightDuration)
        {
            var duration = Settings.lightDuration - timeDifference;
            var colorOffset = (m_LightProperties.lightColor - m_Light2D.color) / Settings.lightDuration *
                              timeDifference;
            m_Light2D.color += colorOffset;
            DOTween.To(() => m_Light2D.color, c => m_Light2D.color = c, m_LightProperties.lightColor,
                duration);
            DOTween.To(() => m_Light2D.intensity, i => m_Light2D.intensity = i, m_LightProperties.lightIntensity,
                duration);
        }
        else
        {
            m_Light2D.color = m_LightProperties.lightColor;
            m_Light2D.intensity = m_LightProperties.lightIntensity;
        }
    }
}