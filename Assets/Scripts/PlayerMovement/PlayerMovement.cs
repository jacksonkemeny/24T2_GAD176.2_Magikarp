using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        #region VariablesNeededToRun
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed = 8f;
        [SerializeField] private float jumpPower = 7f;
        private bool isGrounded;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            // This will add the players rigidbody to a variable
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // This will allow the player to move
            MovePlayer();
        }

        private void Update()
        {
            // This will allow the player to jump
            JumpPlayer();
        }

        // These will set the variable isGrounded to true whenever
        // the player is colliding with the ground to ensure it can't
        // jump in the air
        private void OnCollisionEnter2D(Collision2D collision)
        {
            isGrounded = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            isGrounded = false;
        }


        /// <summary>
        /// This will move the player using the player's rigidbody velocity
        /// whenever the player presses the left and right keys
        /// </summary>
        private void MovePlayer()
        {
            float direction = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }


        /// <summary>
        /// This will do the same as above however now it using the space key
        /// to allow the player to jump it will also check to see if the player
        /// is grounded to ensure it can't jump in the air
        /// </summary>
        private void JumpPlayer()
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
        }
    }
}
