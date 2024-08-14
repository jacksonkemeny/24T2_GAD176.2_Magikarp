using SAE_24T2.ReusableGameFramework.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Traps.Projectile
{
    public class NA_RapidProjectileTrap : NA_ProjectileTrap
    {

        #region Variables

        protected int rapidProjectileFireInterval = 2; // variable used for fire interval

        #endregion

        void Start()
        {

            playerReference = FindObjectOfType<JK_PlayerMovement>(); // find reference to player 

            StartCoroutine(ProjectileTimer(rapidProjectileFireInterval)); // triggers parent coroutine with a variable from here

        }
    }
}
