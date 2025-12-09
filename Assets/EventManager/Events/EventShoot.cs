using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventShoot : MonoBehaviour,IEvent
{
    [SerializeField] AudioSource _ShootSound;
    // Start is called before the first frame update
    void Start()
    {
        EventsTypes.EventSubscribe(EventStrings.ShootSound,PlayShootSound);
    }

    public void PlayShootSound()
    { 
       _ShootSound.Play();
    
    }
}
