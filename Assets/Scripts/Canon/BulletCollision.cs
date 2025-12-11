using FactoryPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BulletLifeTime bullet = GetComponent<BulletLifeTime>();

            BulletFactory.Instance.ReturnBullet(bullet);
            EventsTypes.InvokeEvent(EventStrings.PlayerDamage);
        }
    }
}
