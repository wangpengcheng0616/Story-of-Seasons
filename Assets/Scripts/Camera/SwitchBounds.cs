using Cinemachine;
using UnityEngine;

public class SwitchBounds : MonoBehaviour
{
    private PolygonCollider2D m_polygonCollider2D;

    private CinemachineConfiner m_cinemachineConfiner;

    private void Awake()
    {
        m_cinemachineConfiner = GetComponent<CinemachineConfiner>();
    }

    private void Start()
    {
        SwitchConfinerShape();
    }

    private void SwitchConfinerShape()
    {
        m_polygonCollider2D = GameObject.FindGameObjectWithTag("Bounds").GetComponent<PolygonCollider2D>();
        m_cinemachineConfiner.m_BoundingShape2D = m_polygonCollider2D;
        m_cinemachineConfiner.InvalidatePathCache(); // Change at  runtime
    }
}