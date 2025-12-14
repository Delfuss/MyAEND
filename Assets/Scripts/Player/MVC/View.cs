using UnityEngine;
using System.Collections;


public class View : ILifeSubstractSound
{
    private AudioSource _audioSource;
    private MeshRenderer _renderer;
    private MonoBehaviour _monoBehaviour;

    public View(AudioSource audioSource, MeshRenderer renderer, MonoBehaviour monoBehaviour)
    {
        _audioSource = audioSource;
        _renderer = renderer;
        _monoBehaviour = monoBehaviour;
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }

    public void ChangeColor()
    {
        _monoBehaviour.StartCoroutine(ChangeColorDamage());
    }

    private IEnumerator ChangeColorDamage()
    {
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        _renderer.material.color = Color.white;
    }
}
