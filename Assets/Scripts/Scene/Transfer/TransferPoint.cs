using UnityEngine;

public class TransferPoint : MonoBehaviour
{
    [SerializeField] private SceneName sceneName;
    private string m_SceneName;

    [SerializeField] private Vector3 m_ScenePosition; // TODO: Change

    private void Awake()
    {
        InitSceneName();
    }

    private void InitSceneName()
    {
        switch (sceneName)
        {
            case SceneName.FieldScene:
                m_SceneName = Settings.fieldScene;
                break;
            case SceneName.HouseScene:
                m_SceneName = Settings.housecene;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventHandler.CallGameTransferEvent(m_SceneName, m_ScenePosition);
        }
    }
}