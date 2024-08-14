using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Traps
{
    public class NA_SelfDestruct : MonoBehaviour
    {

        // this script automatically self destructs after timer duration
        private void Start()
        {
            StartCoroutine(SelfDestructTimer(5));
        }

        private IEnumerator SelfDestructTimer(int timer) // used to deactive the object connect 
        {
            //Debug.Log("counting self destruct");
            // wait
            yield return new WaitForSeconds(timer);

            Destroy(gameObject);

        }
    }
}
