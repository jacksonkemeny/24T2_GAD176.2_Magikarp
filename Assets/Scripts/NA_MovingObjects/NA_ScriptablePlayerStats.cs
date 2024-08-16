using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Player.Health
{

    // this scriptable object saves the player health
    [CreateAssetMenu(fileName = "player stats", menuName = "Player Max Health", order = 0)]
    public class NA_ScriptablePlayerStats : ScriptableObject
    {
        //onenable
        //variables
        //functions

        public int playerMaximumHealth; // players max health
        public int currentPlayerHealth; // player current health

        private void OnEnable()
        {
            currentPlayerHealth = playerMaximumHealth; // set current health to max health on enbaled
        }

        public void DamagePlayer(int damage) // reduces player health with damage
        {
            if (currentPlayerHealth > 0) // checks if player has more than 0 health
            {
                Debug.Log("Damaging Player");
                currentPlayerHealth -= damage; // reduce player health

                Debug.Log("Player has " + currentPlayerHealth + " health left."); // debug player current health
            }   
            

        }
    }
}

