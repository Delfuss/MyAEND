using UnityEngine;

public class ViewPinchos : IDamages
{
    private readonly AudioSource _audioSource;
    private readonly Animator _animator;
    private readonly string _animTrigger;
    private readonly Renderer _renderer;  // Renderer para cambiar color


    public ViewPinchos(AudioSource audioSource, Animator animator, Renderer renderer, string animTrigger = "Attack")
    {
        _audioSource = audioSource;
        _animator = animator;
        _renderer = renderer;
        _animTrigger = animTrigger;
    }

    public void LifeDamageEffect()
    {
        PlayAudio();
        PlayAnimation();
    }

    public void SetColor(Color color)
    {
        if (_renderer != null)
            _renderer.material.color = color;
    }

    private void PlayAudio()
    {
        _audioSource.Play();
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger(_animTrigger);
    }
}
