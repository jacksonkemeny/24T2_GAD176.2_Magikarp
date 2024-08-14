using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TF_SoundEffect : MonoBehaviour
{
    public AudioClip soundEffect;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //Initialising the audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
        audioSource.playOnAwake = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        //checks to ensure the audio source is found and plays the allocated SFX
        if (audioSource != null && soundEffect != null)
        {
            Debug.Log("Event Success");
            audioSource.Play();
        }
        else
        {
            Debug.Log("Audio Source not found");
        }

    }
}
