using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAD176_ItemPickup_Base
{
    public class TF_ItemPickupDestroy : TF_ItemPickupMain
    {
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        public void Update()
        {
            base.Update();
        }

        //Detects collision prior to deleting the prefab. 
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(playerTag))
            {
                Destroy(gameObject);
                PickupPopUp();
            }
        }

        //Shows desired text for a set amount of time in the allocated UI space. 
        private void PickupPopUp()
        {
            if (textDisplay != null)
            {
                StartCoroutine(textDisplay.ShowTextForDuration("You have collected an item!", 5f));
            }
            else
            {
                Debug.LogError("TextDisplay is not assigned!");
            }

        }


    }
}