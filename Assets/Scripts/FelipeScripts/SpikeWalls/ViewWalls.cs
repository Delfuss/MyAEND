using UnityEngine;

public class ViewWalls
{
    private readonly AudioSource _audio;
    private readonly Animator _animator;
    private readonly string _trigger;

    public ViewWalls(AudioSource audio, Animator animator, string trigger = "Damage")
    {
        _audio = audio;
        _animator = animator;
        _trigger = trigger;
    }

    public void PlayFeedback()
    {
        _audio?.Play();
        _animator?.SetTrigger("Damage");
    }
}
