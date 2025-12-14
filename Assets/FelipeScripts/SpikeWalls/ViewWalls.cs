using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewWalls : ISound,IAnimation
{

    private AudioSource _audio;
    private Animator _Animator;

    public ViewWalls(AudioSource audio,Animator animation)
    {
        _audio = audio;
        _Animator = animation;
    }

    public void PlaySound()
    {
      _audio.Play();
    }

    public void PlayAnimation()
    {
        _Animator.SetTrigger("Damage");
    }
}
