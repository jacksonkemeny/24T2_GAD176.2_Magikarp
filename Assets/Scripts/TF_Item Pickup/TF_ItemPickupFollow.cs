using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAD176_ItemPickup_Base
{ 
public class TF_ItemPickupFollow : TF_ItemPickupMain
    {

    [SerializeField] private Vector2 followOffset = new Vector2(1.5f, 1);
    private bool isFollowingPlayer = false;
    [SerializeField] private float bounceAmplitude = 0.3f; 
    [SerializeField] private float bounceFrequency = 10f;
    private float bounceTimer = 0f;


        // Start is called before the first frame update
        void Start()
    {
            base.Start();

        }

    // Update is called once per frame
    public void Update()
    {

        base.Update();

        if (!isFollowingPlayer && playerLocation != null && pickupItemRB != null)
        {
                DetectPlayerAndMove();
            }
        else if (isFollowingPlayer && playerLocation != null)
        {
            FollowPlayerWithBounce();
        }
    }
        //Adds a bouncing animation once the item has been collected and begins following. 
    private void FollowPlayerWithBounce()
        {
            
            bounceTimer += Time.deltaTime * bounceFrequency;

            float bounceOffset = Mathf.Sin(bounceTimer) * bounceAmplitude;

            Vector2 targetPosition = (Vector2)playerLocation.position + followOffset;
            targetPosition.y += bounceOffset;

            transform.position = targetPosition;

        }
        //Collider that detects the player and checks that the prefab is 'following'. Also destroys RB to ensure the prefab doesn't affect player movement. 
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(playerTag))
            {

                isFollowingPlayer = true;
                transform.SetParent(playerLocation);
                Destroy(pickupItemRB); 
                Debug.Log("You have a follower!");
                FollowerPopUp();
            }
        }

        //Shows a UI popup for a set amount of time. 
    private void FollowerPopUp()
        {
            if (textDisplay != null)
            {
                StartCoroutine(textDisplay.ShowTextForDuration("You have a new follower!", 5f)); 
            }
            else
            {
                Debug.LogError("TextDisplay is not assigned!");
            }

        }

    }
}