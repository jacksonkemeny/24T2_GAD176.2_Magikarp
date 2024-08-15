using SAE_24T2.ReusableGameFramework.Events.PadEvents;
using SAE_24T2.ReusableGameFramework.AudioPlayers.SFXPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Pad.BouncePad
{
    public class BouncePad : MonoBehaviour
    {
        public float upForce = 700f;
        private JK_SoundEffectPlayer sfxPlayer;
        private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            sfxPlayer = GetComponent<JK_SoundEffectPlayer>();
            sfxPlayer.SetupAudioSource(audioSource);
        }

        private void OnEnable()
        {
            PadEvents.OnBouncePadPressed.AddListener(Bounce);
        }

        private void OnDisable()
        {
            PadEvents.OnBouncePadPressed.RemoveListener(Bounce);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Collided");
                audioSource.Play();
                PadEvents.OnBouncePadPressed.Invoke(collision);
            }
        }

        public void Bounce(Collision2D collision)
        {
            collision.rigidbody.AddForce(transform.up * upForce);
        }
    }
}
