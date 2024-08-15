using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.ScriptableObjects.JK_SoundEffect
{
    [CreateAssetMenu(fileName = "New Sound Effect", menuName = "Create New Sound Effect", order = 0)]
    public class JK_SoundEffect : ScriptableObject
    {
        public AudioClip soundEffect;
    }
}
