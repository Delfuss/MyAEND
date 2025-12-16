using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private ISceneLoader sceneLoader;
    private SimpleLoadingUI loadingUI;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<UnitySceneLoader>();
        loadingUI = FindObjectOfType<SimpleLoadingUI>();
    }

    public void LoadScene(string sceneName)
    {
        if (sceneLoader == null)
            sceneLoader = FindObjectOfType<UnitySceneLoader>();
        if (loadingUI == null)
            loadingUI = FindObjectOfType<SimpleLoadingUI>();

        loadingUI?.ShowLoading();
        sceneLoader?.Load(sceneName);
    }
}
