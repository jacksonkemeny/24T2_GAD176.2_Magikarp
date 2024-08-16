using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffect", menuName = "ScriptableObjects/SoundEffect", order = 1)]
public class TF_SoundEffect : ScriptableObject
{
    public AudioClip soundEffect;
    private AudioSource audioSource;

    public void Initialize(AudioSource source)
    {
        // Set the AudioSource to the one passed from the calling object
        audioSource = source;
        audioSource.clip = soundEffect;
        audioSource.playOnAwake = false;
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

