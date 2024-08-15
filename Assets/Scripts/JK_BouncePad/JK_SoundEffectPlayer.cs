using SAE_24T2.ReusableGameFramework.ScriptableObjects.JK_SoundEffect;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.AudioPlayers.SFXPlayer
{
    public class JK_SoundEffectPlayer : MonoBehaviour
    {
        public JK_SoundEffect BouncePadSFX;

        public void SetupAudioSource(AudioSource source)
        {
            source.clip = BouncePadSFX.soundEffect;
        }
    }
}
