using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform startPoint;
    public float bulletSpeed = 100f;

    public void FireBullet()
    {
        var bullet = Instantiate(bulletPrefab, startPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = this.transform.forward * bulletSpeed;
    }
}
