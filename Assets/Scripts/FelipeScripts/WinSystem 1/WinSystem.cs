using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSystem : MonoBehaviour,ITag
{
    private ILoad _Load;

    [SerializeField] WinLoad LoadScript;  
    public string Tag { get; private set; } = "Player";

    [SerializeField] int IndexToLoad;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            LoadScript.StartCoroutine(LoadScript.LoadScene(IndexToLoad));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            LoadScript.StartCoroutine(LoadScript.LoadScene(IndexToLoad));
        }
    }
}
