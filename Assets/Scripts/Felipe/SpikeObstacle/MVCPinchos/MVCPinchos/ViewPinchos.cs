using UnityEngine;



public class ViewPinchos : ILifeDamage
{
    private readonly AudioSource _audioSource;
    private readonly GameObject _particles;
    private readonly Animator _animator;
    private readonly string _animTrigger;

    public ViewPinchos(AudioSource audioSource, GameObject particles, Animator animator, string animTrigger = "Attack")
    {
        _audioSource = audioSource;
        _particles = particles;
        _animator = animator;
        _animTrigger = animTrigger;
    }

    public void LifeDamageEffect()
    {
        PlayAudio();
        PlayAnimation();
    }

   

    private void PlayAudio()
    {
        _audioSource?.Play();
    }

    private void PlayAnimation()
    {
        _animator?.SetTrigger(_animTrigger);
    }
}
