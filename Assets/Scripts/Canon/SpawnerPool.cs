using System.Collections;
using UnityEngine;

namespace FactoryPool
{
    [RequireComponent(typeof(AudioSource))]

    public class SpawnerPool : MonoBehaviour
    {
        [SerializeField] AudioSource _AudioSource;
        [SerializeField] GameObject Canon;
        [SerializeField] Vector3 Position;
        [SerializeField] float fireRate = 10f; // segundos
         Rigidbody _rb;

        private void Start()
        {
            StartCoroutine(AutoFire());
        }

        private IEnumerator AutoFire()
        {
            while (true)
            {
                var bullet = BulletFactory.Instance.GetBullet();
                _rb = bullet.GetComponent<Rigidbody>();
                bullet.transform.position = Canon.transform.position + Position;

                if (_rb != null)
                {
                    _rb.velocity = -bullet.transform.forward * 10f;
                    _AudioSource.Play();
                }

                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}


