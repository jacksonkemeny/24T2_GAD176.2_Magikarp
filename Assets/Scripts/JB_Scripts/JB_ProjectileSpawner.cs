using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JB_ProjectileSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected Transform projectileSpawnPoint;
   [SerializeField] private float shootInterval = 2f;  // Time interval between shots
   [SerializeField] private float projectileSpeed = 5f;  // speed pf projectile
  [SerializeField]  private float shootTimer;
    [SerializeField] private Vector2 velocitySequence;
    public JB_DotInfo TextUi;

    void Start()
    {
       
        shootInterval = 2;
        shootTimer = shootInterval;
        Debug.Log(shootInterval);
    }

   public void Shoot()
    {
        GameObject damageZone = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
      //  Vector2(velocity up and slightly to the left)
      damageZone.GetComponent<Rigidbody2D>().velocity = velocitySequence;
        damageZone.GetComponent<JB_ProjectileDamageOverTime>().dotInfo = TextUi;
    }
    
    void Update()
    {

        if (player != null)
        {

            

            // Countdown timer

            shootTimer -= Time.deltaTime;

            if (shootTimer <= 0)
            {
                shootTimer = shootInterval;
                Shoot();
            }

        }
    }

}
