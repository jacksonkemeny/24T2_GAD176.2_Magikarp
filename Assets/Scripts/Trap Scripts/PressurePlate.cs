using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SAE_24T2.ReusableGameFramework.Traps.PressurePlate
{

    // this script detects when the player stands on the pressure plate trap
    public class PressurePlate : MonoBehaviour
    {

        #region Variables

        [SerializeField] protected GameObject trapTriggerText;

        #endregion

        protected void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "Player") // runs only if player tag is connected to the other object
            {
                float distanceToTrap = Vector2.Distance(transform.position, other.transform.position); // gets the distance from the other collider
                //Debug.Log("Player Distance " + distanceToTrap); // debug distance

                if (distanceToTrap < 1) // checks if close enough to pressure plate
                {
                    //Debug.Log("Player Activated Trap: " + gameObject.name);
                    
                    trapTriggerText.SetActive(true);

                }
            }
        }
    }
}
