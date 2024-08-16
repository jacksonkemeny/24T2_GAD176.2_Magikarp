using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JK_DisappearingPlatform : MonoBehaviour
{
    #region All the variables needed to run
    private Color platformColor;
    [SerializeField] private float fadeSpeed = 3f;
    [SerializeField] private float fadeInDelayInSeconds = 2f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // This will set the platform color to be the sprite renderer's color
        platformColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the thing the platform hits is a player it will start the FadePlatformInOutRoutine
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadePlatformInOutRoutine());
        }
    }

    /// <summary>
    /// This will fade platform to the alpha of 0 and then it will turn off its collider
    /// After it does this will then fade it back in while turning on the collider
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadePlatformInOutRoutine()
    {
        while (platformColor.a > 0)
        {
            platformColor.a = Mathf.MoveTowards(platformColor.a, 0, Time.deltaTime * fadeSpeed);
            GetComponent<SpriteRenderer>().color = platformColor;
            yield return null;
        }

        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(fadeInDelayInSeconds);

        GetComponent<BoxCollider2D>().enabled = true;

        while (platformColor.a < 1)
        {
            platformColor.a = Mathf.MoveTowards(platformColor.a, 1, Time.deltaTime * fadeSpeed);
            GetComponent<SpriteRenderer>().color = platformColor;
            yield return null;
        }

        yield return null;
    }
}
