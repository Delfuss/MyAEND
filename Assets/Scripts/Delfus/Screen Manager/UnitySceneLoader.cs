using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitySceneLoader : MonoBehaviour, ISceneLoader
{
    public void Load(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    private IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

        while (!op.isDone)
            yield return null;
    }
}
