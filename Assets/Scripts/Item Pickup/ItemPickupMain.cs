using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GAD176_ItemPickup_Base 
{ 

public class ItemPickupMain : MonoBehaviour
{
        [SerializeField] protected float moveSpeed = 1f; 
        [SerializeField] protected float detectionDistance = 5f; 
        public Transform playerLocation;
        [SerializeField] protected Rigidbody2D pickUpItemOneRigidBody;
        [SerializeField] protected string playerTag = "Player";

        // Start is called before the first frame update
        void Start()
    {
            if (playerLocation == null)
            {
                Debug.LogError("Player location is not set.");
            }
            if (pickUpItemOneRigidBody == null)
            {
                Debug.LogError("Rigidbody2D is not set.");
            }

        }

    // Update is called once per frame
    public void Update()
    {
            if (playerLocation != null && pickUpItemOneRigidBody != null)
            {
                MoveTowardPlayer(playerLocation.position);
            }
        }

    protected virtual void MoveTowardPlayer(Vector2 playerPosition)
        {
            if (Vector2.Distance(transform.position, playerPosition) < detectionDistance)
            {
                Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
                pickUpItemOneRigidBody.AddForce(direction * moveSpeed);
            }
        }



   


    }
}