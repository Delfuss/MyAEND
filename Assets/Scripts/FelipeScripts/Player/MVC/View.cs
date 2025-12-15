using UnityEngine;
using System.Collections;


public class View : ILifeSubstractSound,IAnimationsStates
{
    private AudioSource _audioSource;
    private MeshRenderer _renderer;
    private MonoBehaviour _monoBehaviour;
    private Animator _Animation;
    private IPlayerStats _model;

    public View(AudioSource audioSource, MeshRenderer renderer, MonoBehaviour monoBehaviour, Animator animation, IPlayerStats model)
    {
        _audioSource = audioSource;
        _renderer = renderer;
        _monoBehaviour = monoBehaviour;
        _Animation = animation;
        _model = model;
    }

    public bool AJump { get; private set; }

    public void PlayAnimation()
    {
        if (_model.Jump == true)
        {
          _Animation.SetTrigger("Jump");
        }
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
