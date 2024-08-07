using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JB_ProjectileSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
    private float shootInterval = 2f;  // Time interval between shots
    private float projectileSpeed = 5f;  // speed pf projectile
    private float shootTimer;
    [SerializeField] private Vector2 velocitySequence;

    void Start()
    {
        shootTimer = shootInterval;
    }

    void Shoot()
    {
        GameObject damageZone = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
      //  Vector2(velocity up and slightly to the left)
      damageZone.GetComponent<Rigidbody2D>().velocity = velocitySequence;
    }
    
    void Update()
    {

        if (player != null)
        {



            // Countdown timer

            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                Shoot();
                shootTimer = shootInterval;
                
            }

        }
    }

}