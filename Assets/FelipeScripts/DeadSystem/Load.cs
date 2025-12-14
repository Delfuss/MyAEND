using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour,ILoad
{
    public List<string> SceneName = new List<string>();
    public void LoadScene( int Index)
    {
        SceneManager.LoadScene(SceneName[Index]);
    }
}
