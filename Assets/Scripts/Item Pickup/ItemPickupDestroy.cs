using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAD176_ItemPickup_Base
{
    public class ItemPickupDestroy : ItemPickupMain
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public void Update()
        {
            base.Update();
        }

        protected void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(playerTag))
            {
                Destroy(gameObject);
            }
        }

         
    }
}