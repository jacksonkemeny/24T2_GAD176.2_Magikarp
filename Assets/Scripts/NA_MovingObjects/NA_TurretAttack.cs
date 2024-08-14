using SAE_24T2.ReusableGameFramework.Player.Health;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.MovingObjects.TurretAttack
{

    // this script is used for the turret attack the player
    public class NA_TurretAttack : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int turretViewDistance; // distance the turrent can see
        [SerializeField] private int turretDamage; // damage of the turret

        [SerializeField] private GameObject playerLocation; // player's location | manually add this in the inspector
        [SerializeField] private NA_PlayerHealth playerHealth; // player health script | manually add this in the inspector

        [SerializeField] private float playerInvincibilityinSeconds = 2f; // how long the player is invincible for after an attack
        [SerializeField] private float playerDistance; // how far the player is

        [SerializeField] private bool canThisTurretHurtPlayer; // true or false if turrent can hurt player
        [SerializeField] private bool canRaySeeTarget; // determines if the raycast can see the player
        #endregion
        void Start()
        {
            turretViewDistance = 10;
            canThisTurretHurtPlayer = true;
            turretDamage = 20;
            canRaySeeTarget = false;
        }

        void Update()
        {
            playerDistance = Vector2.Distance(transform.position, playerLocation.transform.position); // distance from player

        }

        private void FixedUpdate()
        {
            if (playerDistance < turretViewDistance) // can turret see player?
            {
                // Debug.Log("Running Functions");
                Raycast();
                
            }

        }

        public void DamagePlayer() // used to damage the player
        {
            if (canThisTurretHurtPlayer != false && playerHealth.currentPlayerHealth > 0) // checks if the player can be hit
            {
                StartCoroutine(TurretAttackPlayer());
            } 



        }

        private IEnumerator TurretAttackPlayer() // turrent hurts that player
        {
            canThisTurretHurtPlayer = false; // player cannot be hit
            playerHealth.currentPlayerHealth -= turretDamage; // damage player

            yield return new WaitForSeconds(playerInvincibilityinSeconds); // wait for the invinbility frames to be able to get hit by the turrent

            canThisTurretHurtPlayer = true; // player can be hit
        }

        void Raycast() // player detection 
        {

            // Debug.DrawLine(transform.position, transform.forward * turretRaycastDistance, Color.red);


            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerLocation.transform.position - transform.position); // raycast to the player
            {
                if (hit.collider != null) // checks that it actually hit something
                {
                    canRaySeeTarget = hit.collider.CompareTag("Player"); // true or false if the object has player tag
                    if (canRaySeeTarget) // if true debug green line
                    {
                        Debug.DrawRay(transform.position, playerLocation.transform.position - transform.position, Color.green); // ray green if see target
                        DamagePlayer();
                    }
                    else // if false debug red line
                    {
                        Debug.DrawRay(transform.position, playerLocation.transform.position - transform.position, Color.red); // ray red if cant see target
                    }                  
                }
            }
        }

    }
}

