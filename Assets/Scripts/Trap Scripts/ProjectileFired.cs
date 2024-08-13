using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


namespace SAE_24T2.ReusableGameFramework.Traps.Projectile
{

    // this is used on the projectile to give it a force to move
    public class ProjectileFired : MonoBehaviour
    {
        #region Variables

        public UnityEvent ProjectileHitPlayer = new UnityEvent(); // event used to triggering the projectile
        private int projectilePower = 2; // power of the projectile moving
        Rigidbody2D projectileRigidBody2D; // RB2D of projectile fired

        #endregion

        private void OnEnable()
        {
           ProjectileHitPlayer.AddListener(ProjectileTriggered); // add on enabled
        }

        private void OnDisable()
        {
            ProjectileHitPlayer.AddListener(ProjectileTriggered); // removed on disabled to prevent spam  
        }

        void Start()
        {
           projectileRigidBody2D = GetComponent<Rigidbody2D>(); // sets rigidbody (object should always have a rigidbody when using a projectile)
           projectileRigidBody2D.AddForce(Vector3.right * projectilePower, ForceMode2D.Impulse); // adds force to the project when it spawns in
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player") // checks for player
            {
                // if(ProjectileHitPlayer != null)
                // {
                //     ProjectileHitPlayer.Invoke();
                // }

                ProjectileHitPlayer?.Invoke(); // starts the unity event if there is something listening

            }
        }

        private void ProjectileTriggered() // function for when projectile triggers with player
        {

            Debug.Log("Projectile Triggered");
            Destroy(gameObject);
        }

    }
}
