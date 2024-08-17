using SAE_24T2.ReusableGameFramework.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;


namespace SAE_24T2.ReusableGameFramework.Traps.Projectile
{

    // this is a parent script that helps with repeatedly shooting a projectile
    public class NA_ProjectileTrap : MonoBehaviour
    {

        #region Variables

        protected int defaultProjectileFireintervalSeconds; // interval between firing
        [SerializeField] protected JK_PlayerMovement playerReference; // player reference
        [SerializeField] protected GameObject projectileToFire; // object that is fired
        public int trapDetectionRange = 10;

        #endregion

        void Start()
        {
            defaultProjectileFireintervalSeconds = 4;

            playerReference = FindObjectOfType<JK_PlayerMovement>(); // find reference to player 

            StartCoroutine(ProjectileTimer(defaultProjectileFireintervalSeconds));

        }


        void Update()
        {

        }

        protected IEnumerator ProjectileTimer(int seconds) // used to randomly move objects repeatedly
        {
            Debug.Log("Preparing to fire projectile");
            yield return new WaitForSeconds(seconds);

            ShootProjectile(); // fire projectile

            StartCoroutine(ProjectileTimer(seconds)); // repeats itself

        }

        protected void ShootProjectile() // fires the projectile
        {
            if (playerReference != null)
            {
                if (Vector2.Distance(transform.position, playerReference.transform.position) < trapDetectionRange) // checks if it's in range
                {
                    // fire projectile
                    Instantiate(projectileToFire, gameObject.transform.position + Vector3.right * .75f, Quaternion.identity); // spawns the projectile
                }
            }
        }
    }
}

