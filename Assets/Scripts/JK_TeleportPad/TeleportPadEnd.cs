using SAE_24T2.ReusableGameFramework.Events.PadEvents;
using SAE_24T2.ReusableGameFramework.Pad.TeleportPad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPadEnd : TeleportPadStart
{
    private Transform teleportPadStartTransform;

    protected override void OnEnable()
    {
        PadEvents.OnTeleportPadEndPressed.AddListener(TeleportStart);
    }

    protected override void OnDisable()
    {
        PadEvents.OnTeleportPadEndPressed.RemoveListener(TeleportStart);
    }

    protected override void Start()
    {
        teleportPadStartTransform = transform;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasTeleported)
        {
            StartFadeInFadeOutCoroutine();
            PadEvents.OnTeleportPadEndPressed.Invoke(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        hasTeleported = false;
    }

    protected override void TeleportStart(Collision2D collision)
    {
        Vector3 direction = teleportPadStartTransform.right - collision.transform.position;
        collision.transform.position += direction;
    }

    protected override void StartFadeInFadeOutCoroutine()
    {
        base.StartFadeInFadeOutCoroutine();
    }
}
