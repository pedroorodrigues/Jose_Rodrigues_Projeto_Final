using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float fireRate = 1.5f;
    [SerializeField] private Transform firePoint;

    private void Start()
    {
        StartCoroutine(ShootOnceAndRepeat());
    }

    private IEnumerator ShootOnceAndRepeat()
    {
        yield return new WaitForSeconds(fireRate);

        FireBullet();
        StartCoroutine(ShootOnceAndRepeat());
    }

    private void FireBullet()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint != null ? firePoint.position : transform.position;
            bullet.transform.rotation = Quaternion.identity;
            bullet.SetActive(true);
        }
    }
}
