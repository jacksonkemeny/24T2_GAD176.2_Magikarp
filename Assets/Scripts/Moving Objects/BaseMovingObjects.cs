using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.MovingObjects.BaseMovement
{

    // This script allows objects attached to this script to move to points (transforms) repeatedly 
    public class BaseMovingObjects : MonoBehaviour
    {
        
        #region Variables
        [SerializeField] private int currentWaypoint = 0;
        [SerializeField] private int distanceFromPoint; // distance from point to perform an action

        
        private bool reverseWaypoints; // goes backwards in the list
        [SerializeField] private bool fowardWaypoints; // ONLY TURN ONE ON - goes fowards in the list

        [SerializeField] private bool randomWaypoints; // ONLY TURN ONE ON - for making points random
        [SerializeField] private bool fowardsOnlyWaypoints; // ONLY TURN ONE ON - makes points go in order (foward)
        
        [SerializeField] private float objectMovementSpeed; // set this variable in the inspector
        [SerializeField] private float objectRotationSpeed; // set this variable in the inspector - for objects that look at something   

        [SerializeField] private GameObject[] placedWaypoints; // where the points are placed in the inspector
        #endregion
        void Start()
        {
            objectMovementSpeed = 5;
            distanceFromPoint = 1; // this should not change

            Debug.Log("This is the BaseMovingObject script"); // debug the name of this script
        }

        private void FixedUpdate()
        {

            ObjectMovement();

        }

        public void ObjectMovement()
        {
            if (Vector2.Distance(placedWaypoints[currentWaypoint].transform.position, transform.position) < distanceFromPoint) // checks if object is close enough to the point
            {
                // Debug.Log("Waypoint " + currentWaypoint + " has been reached"); // waypoint debug test

                // object will go in reverse when reaching the end of the list vice versa
                #region Reversing Waypoints
                if (fowardWaypoints == true && reverseWaypoints == false && randomWaypoints == false && fowardsOnlyWaypoints == false) // foward in the list
                {
                    currentWaypoint++;

                    if (currentWaypoint >= placedWaypoints.Length) // resets to the starting point
                    {
                        currentWaypoint -= 1;
                        reverseWaypoints = true;
                        fowardWaypoints = false;
                    }
                }

                else if (reverseWaypoints == true && randomWaypoints == false && fowardsOnlyWaypoints == false && fowardWaypoints == false)
                {
                    currentWaypoint--;

                    if (currentWaypoint < 0)
                    {
                        currentWaypoint += 1;
                        reverseWaypoints = false;
                        fowardWaypoints = true;

                    }
                }
                #endregion

                // object will randomly go to points placed in the list
                #region Random Waypoints
                else if (randomWaypoints == true && reverseWaypoints == false && fowardsOnlyWaypoints == false && fowardWaypoints == false)
                {
                    currentWaypoint = Random.Range(0, placedWaypoints.Length);
                }
                #endregion

                // object will only go foward and will restart when reaching the end of the list
                #region Fowards Only Waypoints
                else if (fowardsOnlyWaypoints == true && reverseWaypoints == false && randomWaypoints == false && fowardWaypoints == false)
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

            transform.position = Vector2.MoveTowards(transform.position, placedWaypoints[currentWaypoint].transform.position, Time.deltaTime * objectMovementSpeed); // moves script object to current point

        }

    }
}

