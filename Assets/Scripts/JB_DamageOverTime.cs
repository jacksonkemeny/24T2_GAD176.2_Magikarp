using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using SAE_24T2.GAD176.ReusableGameFramework.Player.Stats;

public class JB_DamageOverTime : JB_DamageZoneMovement
{
    public JB_PlayerStats target;  // Assign this in the Inspector
    private int damagePerTick = 5;
    private float duration = 5f;
    private float tickInterval = 1f;

    private void Start()
    {
     //   StartCoroutine(ApplyDamageOverTime());
    }

    private System.Collections.IEnumerator ApplyDamageOverTime()
    {
        float totalTicks = duration / tickInterval;

        for (int i = 0; i < totalTicks; i++)
        {
            target.TakeDamage(damagePerTick);
            yield return new WaitForSeconds(tickInterval);
        }
    }
}
