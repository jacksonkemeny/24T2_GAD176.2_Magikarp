using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JB_DamageZoneMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject damageZonePrefab;
    public Transform DamageZoneSpawnPoint;
    public float shootInterval = 2f;  // Time interval between shots
    public float projectileSpeed = 5f;
    private float shootTimer;
    [SerializeField] private Vector2 velocitySequence;

    void Start()
    {
        shootTimer = shootInterval;
    }

    void Shoot()
    {
        GameObject damageZone = Instantiate(damageZonePrefab, DamageZoneSpawnPoint.position, Quaternion.identity);
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
