using System;
using UnityEngine;

namespace FactoryPool
{
    public class BulletLifeTime : MonoBehaviour, ILifeTime, IBullet
    {
        public Transform Transform => this.transform;

        public float LifeTime { get; set; } = 4f;

        private float _currentLifeTime;

        private Action<IBullet> _returnToPoolCallback;

        public void Initialize(Action<IBullet> returnToPoolCallback, float lifeTime)
        {
            _returnToPoolCallback = returnToPoolCallback;
            LifeTime = lifeTime;
        }

        private void OnEnable()
        {
            _currentLifeTime = LifeTime;
        }

        private void Update()
        {
            _currentLifeTime -= Time.deltaTime;

            if (_currentLifeTime <= 0)
            {
                Expire();
            }
        }

        private void Expire()
        {
            _returnToPoolCallback?.Invoke(this);
        }

        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}
