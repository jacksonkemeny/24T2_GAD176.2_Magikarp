using SAE_24T2.ReusableGameFramework.Events.PadEvents;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SAE_24T2.ReusableGameFramework.Pad.TeleportPad
{
    public class TeleportPadStart : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroup;
        private Transform teleportPadEndTransform;
        [SerializeField] protected float teleportUIFadeSpeed = 3f;
        [SerializeField] protected float delayToFadeOut = 1f;
        protected bool hasTeleported = false;

        protected virtual void OnEnable()
        {
            PadEvents.OnTeleportPadStartPressed.AddListener(TeleportStart);
        }

        protected virtual void OnDisable()
        {
            PadEvents.OnTeleportPadStartPressed.RemoveListener(TeleportStart);
        }

        protected virtual void Start()
        {
            teleportPadEndTransform = FindObjectOfType<TeleportPadEnd>().transform;
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                StartFadeInFadeOutCoroutine();
                PadEvents.OnTeleportPadStartPressed.Invoke(collision);
                hasTeleported = true;
            }
        }

        protected virtual void TeleportStart(Collision2D collision)
        {
            Vector3 direction = teleportPadEndTransform.right - collision.transform.position;
            collision.transform.position += direction;
        }

        protected virtual void StartFadeInFadeOutCoroutine()
        {
            Debug.Log("Player Collided with Teleport Start");
            StartCoroutine(TeleportUIFadeInFadeOut());
        }

        protected IEnumerator TeleportUIFadeInFadeOut()
        {
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 1, Time.deltaTime * teleportUIFadeSpeed);
                yield return null;
            }

            yield return new WaitForSeconds(delayToFadeOut);

            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, 0, Time.deltaTime * teleportUIFadeSpeed);
                yield return null;
            }
        }
    }
}
