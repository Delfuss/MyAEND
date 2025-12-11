using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPool
{
    public class BulletFactory : MonoBehaviour
    {
        public static BulletFactory Instance { get; private set; }

        [SerializeField] BulletLifeTime _bulletPrefab;

        Pool<BulletLifeTime> _pool;

        private void Awake()
        {
            Instance = this;

            _pool = new Pool<BulletLifeTime>(CreateObject, TurnOn, TurnOff, 10);
        }

        BulletLifeTime CreateObject()
        {
            var result = Instantiate(_bulletPrefab);
            return result;
        }

        void TurnOn(BulletLifeTime b)
        {
            b.gameObject.SetActive(true);
        }
        
        void TurnOff(BulletLifeTime b)
        {
            b.gameObject.SetActive(false);
        }

        public BulletLifeTime GetBullet()
        {
            return _pool.GetObject();
        }

        public void ReturnBullet(BulletLifeTime bullet)
        {
            _pool.ReturnObjectToPool(bullet);
        }
    }
}
