using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSystem : MonoBehaviour,ITag
{
    private ILoad _Load;

    [SerializeField] Load LoadScript;  
    public string Tag { get; private set; } = "Obstacle";

    [SerializeField] int IndexToLoad;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            LoadScript.StartCoroutine(LoadScript.LoadScene(IndexToLoad));
        }
    } 
}
