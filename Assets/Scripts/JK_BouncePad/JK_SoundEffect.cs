using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.ScriptableObjects.JK_SoundEffect
{
    [CreateAssetMenu(fileName = "New Sound Effect", menuName = "Create New Sound Effect", order = 0)]
    
    // All this class will do is create a scriptable object which stores the audioclip
    // for the sound effect
    public class JK_SoundEffect : ScriptableObject
    {
        public AudioClip soundEffect;
        
    }
}
