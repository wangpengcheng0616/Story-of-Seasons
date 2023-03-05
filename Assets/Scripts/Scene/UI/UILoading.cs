using DG.Tweening;
using UnityEngine;

public class UILoading : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_CanvasGroup;
    private bool m_IsFade;
    private const float s_Duration = 1f;

    private void Awake()
    {
        EventHandler.GameUILoadingEvent += OnGameUILoadingEvent;
    }

    private void OnGameUILoadingEvent(float alpha)
    {
        m_CanvasGroup.alpha = 1;
        m_CanvasGroup.DOFade(0, s_Duration);
    }

    private void OnDestroy()
    {
        EventHandler.GameUILoadingEvent -= OnGameUILoadingEvent;
    }
}