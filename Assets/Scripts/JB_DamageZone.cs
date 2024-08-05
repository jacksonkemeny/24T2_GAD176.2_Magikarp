using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAE_24T2.GAD176.ReusableGameFramework.Player.Stats;

public class JB_DamageZone : MonoBehaviour
{
    [SerializeField] float damageZoneDamage = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<JB_PlayerStats>())
        {
            other.gameObject.GetComponent<JB_PlayerStats>().playerHealth -= damageZoneDamage;
            Debug.Log("HIt!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("wont Hit!");
        if (collision.gameObject.GetComponent<JB_PlayerStats>())
        {
            collision.gameObject.GetComponent<JB_PlayerStats>().playerHealth -= damageZoneDamage;
            Debug.Log("HIt!");
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("wont Hit!");
    //    if (collision.gameObject.GetComponent<JB_PlayerStats>())
    //    {
    //        collision.gameObject.GetComponent<JB_PlayerStats>().playerHealth -= damageZoneDamage;
    //        Debug.Log("HIt!");
    //    }
    //}



    private void damageZoneMovement()
    {

    }


        




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
