using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Player.Health
{

    // health for the turret to deal damage
    public class NA_PlayerHealth : MonoBehaviour
    {

        [SerializeField] private int maxPlayerHealth = 100; // player max health | change this variable for the players health when starting
        public int currentPlayerHealth; // players current health

        // Start is called before the first frame update
        void Start()
        {
            currentPlayerHealth = maxPlayerHealth; // sets player max health as current on start
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (currentPlayerHealth <= 0)
            {
                Debug.Log("Player has died...");
            }
        }
    }

}

