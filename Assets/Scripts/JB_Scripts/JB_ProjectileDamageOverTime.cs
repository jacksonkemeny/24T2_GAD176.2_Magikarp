using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using SAE_24T2.GAD176.ReusableGameFramework.Player.Stats;
using UnityEngine.UI;
using TMPro;

public class JB_ProjectileDamageOverTime : JB_Projectile
{
    public JB_PlayerStats target;  
    private int damagePerTick = 5;
    private float duration = 5f;
    private float tickInterval = 1f;
    private bool isDotOnPlayer;
    public JB_DotInfo dotInfo;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<JB_PlayerStats>() == null)
            return;

        if (dotInfo != null)
        {
            dotInfo.SetActive(); // Call the function from DotInfo
        }
        else
        {
            Debug.LogWarning("DotInfo reference is missing.");
        }

        Debug.Log("Found player");
        isDotOnPlayer = true;
        StopCoroutine(ApplyDamageOverTime());
        target = collision.GetComponent<JB_PlayerStats>();
        StartCoroutine(ApplyDamageOverTime());
    }
    private IEnumerator ApplyDamageOverTime()
    {
        float totalTicks = duration / tickInterval;
        for (int i = 0; i < totalTicks; i++)
        {
            Debug.Log("Hello");
            target.TakeDamage(damagePerTick);
            yield return new WaitForSeconds(tickInterval);

        }
        isDotOnPlayer = false;
        Debug.Log("Dot is false");
        dotInfo.SetFalse();
    }
}
