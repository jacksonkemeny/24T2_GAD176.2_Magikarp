using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public TF_SoundEffect soundEffectScriptableObject;

    void Start()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        soundEffectScriptableObject.Initialize(audioSource);
    }

    void Update()
    {
        

    }

    public void PlaySound()
    {
        soundEffectScriptableObject.PlaySound();
    }
}
