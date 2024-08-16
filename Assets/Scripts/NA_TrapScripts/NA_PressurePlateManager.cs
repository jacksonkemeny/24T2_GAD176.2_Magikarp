using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Traps
{

    // this script has no current functionality besides having the status of if any traps are on - can add extra functions such as an alarm
    public class NA_PressurePlateManager : MonoBehaviour
    {

        public static NA_PressurePlateManager instance;

        public bool isATrapActive = false; // trap status true should happen even if only 1 is active

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            else
            {
                Destroy(this);
            }

        }

        public void APressurePlateIsActive()
        {
            isATrapActive = true;
        }

        public void NoPressurePlateActive()
        {
            isATrapActive = false;
        }
    }
}


