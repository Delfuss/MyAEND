using System.Collections;
using UnityEngine;
using FactoryPool;

public class SpawnerPool : MonoBehaviour,IAutoFire
{
    [SerializeField] private GameObject canon;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float fireRate = 10f;

    private void Start()
    {
        StartCoroutine(AutoFire());
    }

    public IEnumerator AutoFire()
    {
        while (true)
        {
            var bullet = BulletFactory.Instance.GetBullet();
            bullet.Transform.position = canon.transform.position + offset;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = -bullet.Transform.forward * 10f;

            yield return new WaitForSeconds(fireRate);
        }
    }
}

