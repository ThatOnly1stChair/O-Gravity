using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject BulletSpawner;
    public float bulletspeed;

    public float fireRate = 0.5f;
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Shoot") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            GameObject projectile = Instantiate(bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
            projectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f, 0f, bulletspeed));
        }
    }
}
