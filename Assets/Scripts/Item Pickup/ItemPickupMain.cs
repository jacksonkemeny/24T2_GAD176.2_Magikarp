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
        [SerializeField] protected Rigidbody2D pickupItemRB;
        [SerializeField] protected string playerTag = "Player";
        [SerializeField] protected LayerMask detectionLayerMask;
        


        private bool itemPickedUp = false;

        // Start is called before the first frame update
    public void Start()    
      {
            if (playerLocation == null)
            {
                Debug.LogError("Player location is not set.");
            }
            if (pickupItemRB == null)
            {
                Debug.LogError("Rigidbody2D is not set.");
            }

      }

    // Update is called once per frame
    public void Update()
      {
            if (playerLocation != null && pickupItemRB != null)
            {
                DetectPlayerAndMove();
            }
      }


   

    protected virtual void DetectPlayerAndMove()
       {
            Vector2 direction = (playerLocation.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionDistance, detectionLayerMask);

            if (hit.collider != null && hit.collider.CompareTag(playerTag))
            {
                MoveTowardPlayer(hit.point);

            }
       }    

    protected virtual void MoveTowardPlayer(Vector2 playerPosition)
       {
            if (Vector2.Distance(transform.position, playerPosition) < detectionDistance)
            {
                Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
                pickupItemRB.AddForce(direction * moveSpeed);
            }
       }    
    }


}