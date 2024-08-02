using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.MovingObjects.BaseMovement
{

    // this script allows objects attached to this script to move to points (transforms) repeatedly 
    public class BaseMovingObjects : MonoBehaviour
    {
        
        #region Variables
        [SerializeField] private int currentWaypoint = 0; // the current waypoint number in the list 
        [SerializeField] private int distanceFromPoint; // distance from point to perform an action

        
        private bool reverseWaypoints; // goes backwards in the list
        [SerializeField] private bool forwardWaypoints; // (set this variable in the inspector) ONLY TURN ONE ON - goes forwards in the list

        [SerializeField] private bool randomWaypoints; // (set this variable in the inspector) ONLY TURN ONE ON - for making points random
        [SerializeField] private bool forwardsOnlyWaypoints; // (set this variable in the inspector) ONLY TURN ONE ON - makes points go in order (forward)

        [SerializeField] private float objectMovementSpeed; // (set this variable in the inspector) - speed the object moves
        [SerializeField] private float objectRotationSpeed; // not used

        [SerializeField] private GameObject[] placedWaypoints; // where the points are placed in the inspector
        #endregion

        void Start()
        {
            
            distanceFromPoint = 1; // this should not change

            Debug.Log("This is the BaseMovingObject script"); // debug the name of this script
        }

        private void FixedUpdate()
        {

            ObjectMovementMethod();

        }

        public void ObjectMovementMethod() // this tells the objects how to move to different points
        {
            if (Vector2.Distance(placedWaypoints[currentWaypoint].transform.position, transform.position) < distanceFromPoint) // checks if object is close enough to the point
            {
                // Debug.Log("Waypoint " + currentWaypoint + " has been reached"); // waypoint debug test

                // object will go in reverse when reaching the end of the list vice versa
                #region Reversing Waypoints
                if (forwardWaypoints == true && reverseWaypoints == false && randomWaypoints == false && forwardsOnlyWaypoints == false) // foward in the list
                {
                    currentWaypoint++;

                    if (currentWaypoint >= placedWaypoints.Length) // resets to the starting point
                    {
                        currentWaypoint -= 1;
                        reverseWaypoints = true;
                        forwardWaypoints = false;
                    }
                }

                else if (reverseWaypoints == true && randomWaypoints == false && forwardsOnlyWaypoints == false && forwardWaypoints == false)
                {
                    currentWaypoint--;

                    if (currentWaypoint < 0)
                    {
                        currentWaypoint += 1;
                        reverseWaypoints = false;
                        forwardWaypoints = true;

                    }
                }
                #endregion

                // object will randomly go to points placed in the list
                #region Random Waypoints
                else if (randomWaypoints == true && reverseWaypoints == false && forwardsOnlyWaypoints == false && forwardWaypoints == false)
                {
                    currentWaypoint = Random.Range(0, placedWaypoints.Length);
                }
                #endregion

                // object will only go foward and will restart when reaching the end of the list
                #region Fowards Only Waypoints
                else if (forwardsOnlyWaypoints == true && reverseWaypoints == false && randomWaypoints == false && forwardWaypoints == false)
                {
                    currentWaypoint++;
                    if (currentWaypoint >= placedWaypoints.Length) // resets to the starting point
                    {
                        currentWaypoint = 0;

                    }
                }
                #endregion

                else // if nothing above runs
                {
                    Debug.Log("BaseMovingObject.cs: your platform is broken"); // platform error
                }

            }

            MoveObjectToPoints();

        }

        public void MoveObjectToPoints() // this moves the object to the targeted waypoint
        {
            transform.position = Vector2.MoveTowards(transform.position, placedWaypoints[currentWaypoint].transform.position, Time.deltaTime * objectMovementSpeed); // moves script object to current point
        }

    }
}

