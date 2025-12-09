using System.Collections;
using UnityEngine;

public class ViewPinchos : ILifeDamage
{
    private readonly AudioSource _audioSource;
    private readonly MeshRenderer _renderer;
    private readonly GameObject _Particles;

    public ViewPinchos(AudioSource audio,GameObject _ParticlesEffect)
    {
        _audioSource = audio;
        _Particles = _ParticlesEffect;
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
    }



    public void Dispose()
    {
        EventsTypes.EventUnSubscribe(EventStrings.SpikeDamage, LifeDamageEffect);
    }
}
