using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SAE_24T2.ReusableGameFramework.Traps.MoveRadnomly 
{

    // this script randomly moves the connected object in a random direction
    public class RandomForce : MonoBehaviour
    {

        #region Variables

        private int randomNumber; // used for a condition based on the number picked

        [SerializeField] private float objectPower; // power the object will move (reccomended 10-75)
        [SerializeField] private float forceIntervalInSeconds; // time between each random force (reccomended 1-20s)

        #endregion

        void Start()
        {
            StartCoroutine(RandomForceMove());
        }

        // repeated random force
        #region Random Forces
        private IEnumerator RandomForceMove() // used to randomly move objects repeatedly
        {



            randomNumber = Random.Range(1, 3); // 1 or 2 random

            if (randomNumber == 1)
            {
                Vector2 direction1 = new Vector2(-10, 0);
                GetComponent<Rigidbody2D>().AddForce(direction1 * objectPower);
            }

            if (randomNumber == 2)
            {
                Vector2 direction2 = new Vector2(10, 0);
                GetComponent<Rigidbody2D>().AddForce(direction2 * objectPower);
            }
            
            // Debug.Log("Applied Force");

            yield return new WaitForSeconds(forceIntervalInSeconds);

            StartCoroutine(RandomForceMove());

        }
        #endregion
    }
}

