using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.MovingObjects.FaceObject
{

    // this script allows objects attached to this script to look at a target of choice continuously 
    public class NA_FaceObject : MonoBehaviour
    {

        #region Variables

        [SerializeField] GameObject targetToLookAt; // the object that will be looked at | manually add this in the inspector

        [SerializeField] private bool lookFromTop; // (set this variable in the inspector) ONLY TURN ONE ON - top point is closest to target
        [SerializeField] private bool lookFromBottom; // (set this variable in the inspector) ONLY TURN ONE ON - bottom point is closest to target
        [SerializeField] private bool lookFromLeft; // (set this variable in the inspector) ONLY TURN ONE ON - left point is closest to target
        [SerializeField] private bool lookFromRight; // (set this variable in the inspector) ONLY TURN ONE ON - right point is closest to target

        #endregion

        void Start()
        {

        }

        private void FixedUpdate()
        {
            LookAtObject();
        }
        public void LookAtObject() // used to face an object instantly 
        {
            Vector2 direction = targetToLookAt.transform.position - transform.position; // required direction to face the target

            // looks from the top of the object
            #region Look From Up
            if (lookFromTop == true && lookFromBottom == false && lookFromLeft == false && lookFromRight == false) // looks from top
            {
                transform.rotation = Quaternion.FromToRotation(Vector2.up, direction); // rotates the object to face the target
            }
            #endregion

            // looks from the bottom of the object
            #region Look From Down
            else if (lookFromBottom == true && lookFromTop == false && lookFromLeft == false && lookFromRight == false) // looks from bottom
            {
                transform.rotation = Quaternion.FromToRotation(Vector2.down, direction); // rotates the object to face the target
            }
            #endregion

            // looks from the left of the object
            #region Look From Left
            else if (lookFromLeft == true && lookFromTop == false && lookFromBottom == false && lookFromRight == false) // looks from left
            {
                transform.rotation = Quaternion.FromToRotation(Vector2.left, direction); // rotates the object to face the target
            }
            #endregion

            // looks from the right of the object
            #region Look From Right
            else if (lookFromRight == true && lookFromTop == false && lookFromBottom == false && lookFromLeft == false) // looks from right
            {
                transform.rotation = Quaternion.FromToRotation(Vector2.right, direction); // rotates the object to face the target
            }
            #endregion

            else // if nothing above players
            {
                Debug.Log("FaceObject.cs: rotation problem"); // rotation error
            }

        }
    }
}


