using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Transform firePoint;
    [SerializeField] float fireRate = 1;
    [SerializeField] GameObject summonBullet;
    bool canShoot = true;
    
    void Start()
    {
        firePoint = transform;
    }

    void Update()
    {
        
        if (canShoot)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(summonBullet, transform.position, transform.rotation);
        StartCoroutine(ShootReload());
    }
    IEnumerator ShootReload()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

}
