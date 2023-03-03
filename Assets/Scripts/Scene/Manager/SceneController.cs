using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string startScene;

    private void Awake()
    {
        InitScene();
        EventHandler.GameTransferEvent += OnGameTransferEvent;
    }

    private void Start()
    {
        StartCoroutine(LoadScene(startScene));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventHandler.CallGameTransferEvent("HouseScene");
        }
    }

    private static void InitScene()
    {
        SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(scene);
    }

    private IEnumerator SwitchScene(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadScene(sceneName);
    }

    private void OnGameTransferEvent(string sceneName)
    {
        StartCoroutine(SwitchScene(sceneName));
    }

    private void OnDestroy()
    {
        EventHandler.GameTransferEvent -= OnGameTransferEvent;
    }
}