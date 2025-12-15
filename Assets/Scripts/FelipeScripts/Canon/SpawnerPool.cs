using System.Collections;
using UnityEngine;
using FactoryPool;

public class SpawnerPool : MonoBehaviour, IAutoFire
{
    [SerializeField] private GameObject canon;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float fireRate = 10f;

    private IBulletFactory _bulletFactory;

    private void Start()
    {
        _bulletFactory = BulletFactory.Instance;

        StartCoroutine(AutoFire());

    }

    public IEnumerator AutoFire()
    {
        while (true)
        {
            IBullet bullet = _bulletFactory.GetBullet();

            // No depende de BulletLifeTime, solo de la abstracción IBullet
            Transform bulletTransform = bullet.Transform;

            bulletTransform.position = canon.transform.position + offset;

            Rigidbody rb = bulletTransform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = -bulletTransform.forward * 10f;
            }

            yield return new WaitForSeconds(fireRate);
        }
    }
}
