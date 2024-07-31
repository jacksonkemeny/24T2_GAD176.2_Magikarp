using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Player.Health
{

    // TEST PLAYER HEALTH SCRIPT
    public class PlayerHealth : MonoBehaviour
    {

        [SerializeField] private int maxPlayerHealth = 100;
        public int currentPlayerHealth;

        // Start is called before the first frame update
        void Start()
        {
            currentPlayerHealth = maxPlayerHealth;
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

