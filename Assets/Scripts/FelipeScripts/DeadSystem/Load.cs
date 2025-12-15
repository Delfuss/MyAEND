using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour,ILoad
{
    public List<string> SceneName = new List<string>();
    public IEnumerator LoadScene( int Index)
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(SceneName[Index]);
    }
}
