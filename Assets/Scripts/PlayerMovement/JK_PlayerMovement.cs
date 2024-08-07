using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Player.Movement
{
    public class JK_PlayerMovement : MonoBehaviour
    {
        #region VariablesNeededToRun
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private float moveSpeed = 8f;
        [SerializeField] private float jumpPower = 7f;
        private float horizontalKeyInput;
        private bool isGrounded;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            // This will add the players rigidbody to a variable
            rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // This will allow the player to move
            MovePlayer();
        }

        private void Update()
        {
            // This will check for the movement keys
            CheckForMovementKeys();

            // This will check for the jump input and make it jump
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

        private void CheckForMovementKeys()
        {
            horizontalKeyInput = Input.GetAxis("Horizontal");
        }

        /// <summary>
        /// This will move the player using the player's rigidbody velocity
        /// whenever the player presses the left and right keys
        /// </summary>
        private void MovePlayer()
        {
            rigidBody2D.velocity = new Vector2(horizontalKeyInput * moveSpeed, rigidBody2D.velocity.y);
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
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpPower);
            }
        }
    }
}
