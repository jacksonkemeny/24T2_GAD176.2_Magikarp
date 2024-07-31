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
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.SetParent(null);
            }
        }


    }

}

