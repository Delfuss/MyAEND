using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSystem : MonoBehaviour,ITag
{
    private ILoad _Load;

    [SerializeField] int IndexToLoad;

    private void Start()
    {
        _Load = GetComponent<ILoad>();
    }

    public string Tag { get; private set; } = "Obstacle";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tag))
        {
            StartCoroutine(_Load.LoadScene(IndexToLoad));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            StartCoroutine(_Load.LoadScene(IndexToLoad));
        }
    }
}
