using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAE_24T2.GAD176.ReusableGameFramework.Player.Stats;

public class JB_DamageZone : MonoBehaviour
{
    [SerializeField] private float damageZoneDamage = 20;
    

    private void OnTriggerEnter2D(Collider2D collision) // on collision with player, player will take damage 

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



   


        




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
