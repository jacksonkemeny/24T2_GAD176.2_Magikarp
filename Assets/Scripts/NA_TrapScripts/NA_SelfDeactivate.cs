using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SAE_24T2.ReusableGameFramework.Traps
{

    // this script is used to deactivate something that has been enabled automatically
    public class NA_SelfDeactivate : MonoBehaviour
    {

        #region Variables

        public int basicTimeToWaitInSeconds = 5; // basic time to wait

        #endregion

        void Start()
        {
            
        }

        private void OnEnable() // when ever the object connected to this script turns on
        {
            StartCoroutine(DeactivateTimer(basicTimeToWaitInSeconds));
        }

        void Update()
        {

        }

        private IEnumerator DeactivateTimer(int timer) // used to deactive the object connect 
        {
            // wait
            yield return new WaitForSeconds(timer);

            gameObject.SetActive(false);

        }
    }
}
