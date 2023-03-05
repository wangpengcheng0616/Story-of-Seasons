using Cinemachine;
using UnityEngine;

public class SwitchBounds : MonoBehaviour
{
    private PolygonCollider2D m_PolygonCollider2D;

    private CinemachineConfiner m_CinemachineConfiner;

    private void Awake()
    {
        m_CinemachineConfiner = GetComponent<CinemachineConfiner>();
        EventHandler.GameSceneLoadEvent += OnGameSceneLoadEvent;
    }

    private void OnGameSceneLoadEvent()
    {
        // Debug.LogError("//---1");
        var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (!ReferenceEquals(obj, null))
        {
            m_PolygonCollider2D = obj.GetComponent<PolygonCollider2D>();
            // Debug.LogError("//---2");
        }

        m_CinemachineConfiner.m_BoundingShape2D = m_PolygonCollider2D;
        m_CinemachineConfiner.InvalidatePathCache(); // Change at  runtime
    }

    private void OnDestroy()
    {
        EventHandler.GameSceneLoadEvent -= OnGameSceneLoadEvent;
    }
}