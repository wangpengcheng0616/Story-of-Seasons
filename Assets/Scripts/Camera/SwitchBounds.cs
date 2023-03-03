using Cinemachine;
using UnityEngine;

public class SwitchBounds : MonoBehaviour
{
    private PolygonCollider2D m_PolygonCollider2D;

    private CinemachineConfiner m_CinemachineConfiner;

    private void Awake()
    {
        m_CinemachineConfiner = GetComponent<CinemachineConfiner>();
    }

    private void Start()
    {
        SwitchConfinerShape();
    }

    private void SwitchConfinerShape()
    {
        var obj = GameObject.FindGameObjectWithTag("Bounds");
        if (!ReferenceEquals(obj, null))
        {
            m_PolygonCollider2D = obj.GetComponent<PolygonCollider2D>();
        }

        m_CinemachineConfiner.m_BoundingShape2D = m_PolygonCollider2D;
        m_CinemachineConfiner.InvalidatePathCache(); // Change at  runtime
    }
}