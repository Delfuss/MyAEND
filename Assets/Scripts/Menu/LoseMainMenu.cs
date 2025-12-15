using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
       
    }
}
