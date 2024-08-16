using SAE_24T2.ReusableGameFramework.Events.PadEvents;
using SAE_24T2.ReusableGameFramework.AudioPlayers.SFXPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Pad.BouncePad
{
    public class BouncePad : MonoBehaviour
    {
        #region Variables needed to run
        public float upForce = 700f;
        private JK_SoundEffectPlayer sfxPlayer;
        private AudioSource audioSource;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            // Sets all the variable to the sources found in the scene
            audioSource = GetComponent<AudioSource>();
            sfxPlayer = GetComponent<JK_SoundEffectPlayer>();

            // This will run the SetupAudioSource function within sfxPlayer which will
            // Setup the audio to be able to be played
            sfxPlayer.SetupAudioSource(audioSource);
        }

        private void OnEnable()
        {
            // This will subscribe the function bounce to the OnBouncePadPressed event
            PadEvents.OnBouncePadPressed.AddListener(Bounce);
        }

        private void OnDisable()
        {
            // This will unsubscribe the function bounce from the OnBouncePadPressed event
            PadEvents.OnBouncePadPressed.RemoveListener(Bounce);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // This will first check if the bounce pad has collided with the player and
            // if it has it will debug out that it has collided, play a sound
            // and invoke our new event which includes the bounce function
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Collided");
                audioSource.Play();
                PadEvents.OnBouncePadPressed.Invoke(collision);
            }
        }
        public void Bounce(Collision2D collision)
        {
            // This will add some up force to our player whenever it collides with the bounce pad
            // This will allow it to bounce very high
            collision.rigidbody.AddForce(transform.up * upForce);
        }
    }
}
