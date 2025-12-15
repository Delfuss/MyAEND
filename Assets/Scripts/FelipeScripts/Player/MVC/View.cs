using UnityEngine;
using System.Collections;


public class View : IPlayAnimation
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

    public void PlayAnimation()
    {
        if (_model.Jump == true)
        {
          _Animation.SetTrigger("Jump");
            Debug.Log("funciono:)");
        }
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }
}
