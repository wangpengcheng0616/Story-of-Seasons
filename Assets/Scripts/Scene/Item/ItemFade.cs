using DG.Tweening;
using UnityEngine;

#if UNITY_EDITOR
// [RequireComponent(typeof(SpriteRenderer))]
#endif
public class ItemFade : MonoBehaviour
{
    private SpriteRenderer[] m_SpriteRenderer;
    private Color m_ItemColor;

    private enum ItemState
    {
        FadeIn,
        FadeOut
    }

    private void Awake()
    {
        m_SpriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Fade(ItemState itemState, float duration)
    {
        switch (itemState)
        {
            case ItemState.FadeIn:
                m_ItemColor = new Color(1, 1, 1, Settings.fadeInAlpha);
                break;
            case ItemState.FadeOut:
                m_ItemColor = new Color(1, 1, 1, Settings.fadeOutAlpha);
                break;
        }

        foreach (var spriteRender in m_SpriteRenderer)
        {
            spriteRender.DOColor(m_ItemColor, duration);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Fade(ItemState.FadeIn, Settings.fadeInDuration);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Fade(ItemState.FadeOut, Settings.fadeOutDuration);
        }
    }
}