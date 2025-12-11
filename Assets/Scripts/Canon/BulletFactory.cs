using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FactoryPool
{
    public class BulletFactory : MonoBehaviour,IBulletFactory
    {
        public static BulletFactory Instance { get; set; }

        [SerializeField] BulletLifeTime _bulletPrefab;

        Pool<IBullet> _pool;

       [SerializeField] BulletCollision _BulletCollision;

        private void Awake()
        {
            Instance = this;

            _pool = new Pool<IBullet>(CreateObject, TurnOn, TurnOff, 10);

            _BulletCollision.Injection(this);
        }

        IBullet CreateObject()
        {
            var result = Instantiate(_bulletPrefab);
            return result;
        }

        void TurnOn(IBullet b)
        {
            b.Activate();
        }
        
        void TurnOff(IBullet b)
        {
            b.Deactivate();
        }

        public IBullet GetBullet()
        {
            return _pool.GetObject();
        }

        public void ReturnBullet(IBullet Rbullet)
        {
            _pool.ReturnObjectToPool(Rbullet);
        }
    }
}
