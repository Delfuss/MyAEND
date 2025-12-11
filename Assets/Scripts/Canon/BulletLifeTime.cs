using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPool
{
    public class BulletLifeTime : MonoBehaviour
    {
        [SerializeField] float _lifeTime;

        float _currentLifeTime;

        private void OnEnable()
        {
            _currentLifeTime = _lifeTime;
        }

        private void Update()
        {
            _currentLifeTime -= Time.deltaTime;

            if (_currentLifeTime <= 0)
            {
                BulletFactory.Instance.ReturnBullet(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
              BulletFactory.Instance.ReturnBullet(this);
              EventsTypes.InvokeEvent(EventStrings.PlayerDamage);
            }
        }
    }
}
