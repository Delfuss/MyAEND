using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;

    private ISceneLoader sceneLoader;
    private IScreenTransition loadingUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        sceneLoader = GetComponent<ISceneLoader>();
        loadingUI = GetComponent<IScreenTransition>();
    }

    public void LoadScene(string sceneName)
    {
        loadingUI?.ShowLoading();
        sceneLoader?.Load(sceneName);
    }
}
