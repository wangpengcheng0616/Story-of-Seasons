using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Awake()
    {
        InitScene();
        EventHandler.GameTransferEvent += OnGameTransferEvent;
    }

    private void Start()
    {
        EventHandler.CallGameSceneLoadEvent();
    }

    private void InitScene()
    {
        SceneManager.LoadSceneAsync(Settings.uiScene, LoadSceneMode.Additive);
        StartCoroutine(LoadScene(Settings.fieldScene));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(scene);
    }

    private IEnumerator SwitchScene(string sceneName, Vector3 scenePosition)
    {
        // UnLoad Scene
        EventHandler.CallGameSceneUnloadEvent();
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        // Load Scene
        yield return LoadScene(sceneName);
        EventHandler.CallGameUILoadingEvent(0);
        EventHandler.CallGameMoveToPositionEvent(scenePosition);
        EventHandler.CallGameSceneLoadEvent();
    }

    private void OnGameTransferEvent(string sceneName, Vector3 scenePosition)
    {
        StartCoroutine(SwitchScene(sceneName, scenePosition));
    }

    private void OnDestroy()
    {
        EventHandler.GameTransferEvent -= OnGameTransferEvent;
    }
}