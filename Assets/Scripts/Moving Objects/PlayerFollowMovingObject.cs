using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.MovingObjects.FollowObject
{

    // this script allows the player to stay connected to the moving object using a 2D trigger
    public class PlayerFollowMovingObject : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("Player")) // checks for the player tag
            {
                other.transform.SetParent(transform); // connects the player to the object in order to follow its position when entering
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player")) // checks for player tag
            {
                other.transform.SetParent(null); // disconnects the player from the object when leaving
            }
        }


    }

}

