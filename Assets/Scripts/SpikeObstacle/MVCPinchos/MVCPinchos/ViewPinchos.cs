using System.Collections;
using UnityEngine;

public class ViewPinchos : ILifeDamage
{
    private readonly AudioSource _audioSource;
    private readonly MeshRenderer _renderer;
    private readonly GameObject _Particles;
    private readonly Animator _animator;

    public ViewPinchos(AudioSource audio,GameObject _ParticlesEffect,Animator anim)
    {
        _audioSource = audio;
        _Particles = _ParticlesEffect;
        _animator = anim;
    }

    public void Initialize()
    {
        EventsTypes.EventSubscribe(EventStrings.SpikeDamage, LifeDamageEffect);
    }

    public void LifeDamageEffect()
    {
        _Particles.SetActive(false);
        _audioSource.Play();
        _Particles.SetActive(true);
        _animator.SetTrigger("Attack");


    }



    public void Dispose()
    {
        EventsTypes.EventUnSubscribe(EventStrings.SpikeDamage, LifeDamageEffect);
    }
}
