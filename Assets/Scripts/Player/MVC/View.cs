using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : ILifeSubstractSound
{

    private AudioSource _AudioSource;
    private MeshRenderer _Renderer;
    private MonoBehaviour _mono; // Para coroutines


    public View(AudioSource Audio, MeshRenderer Renderer,MonoBehaviour mono)
    {
        EventsTypes.EventSubscribe(EventStrings.PlayerDamage, LifeDamageSound);
        _AudioSource = Audio;
        _Renderer = Renderer;
        _mono = mono;
    }

    


    public void LifeDamageSound()
    { 
       _AudioSource.Play();
        _mono.StartCoroutine(ChangeColorDamage());
    }



    public IEnumerator ChangeColorDamage()
    {
        _Renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        _Renderer.material.color = Color.white;
    }
}
