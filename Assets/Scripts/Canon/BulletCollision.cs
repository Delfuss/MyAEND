using FactoryPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour, ITag
{
    public string Tag { get; set; } = "Player";

    private IBulletFactory _Bullet;

    public void Injection (IBulletFactory bullet)
    { 
      _Bullet = bullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            _Bullet.ReturnBullet(other.gameObject.GetComponent<IBullet>());
            EventsTypes.InvokeEvent(EventStrings.PlayerDamage);
            print("HOLAS");
        }
    }
}
