using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.MovingObjects.BaseMovement
{

    // This script allows objects attached to this script to look at continuously of choice
    public class FaceObject : MonoBehaviour
    {

        [SerializeField] GameObject targetToLookAt;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            LookAtObject();
        }
        public void LookAtObject()
        {
            Vector2 direction = targetToLookAt.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector2.up, direction);
        }
    }
}


