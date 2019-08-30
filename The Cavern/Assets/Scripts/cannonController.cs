using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{
    public Transform bulletSpawner;
    public GameObject bulletPrefab;
    public float spawnRate = 1f;

    private void Start()
    {

        InvokeRepeating("EnemyShooting", 1f, spawnRate);
    }

    public void EnemyShooting()
    {
        Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);

    }
}
