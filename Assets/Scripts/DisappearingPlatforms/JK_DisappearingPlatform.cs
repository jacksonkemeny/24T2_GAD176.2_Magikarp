using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JK_DisappearingPlatform : MonoBehaviour
{
    private Color platformColor;
    [SerializeField] private float fadeSpeed = 3f;
    [SerializeField] private float fadeInDelayInSeconds = 2f;

    // Start is called before the first frame update
    void Start()
    {
        platformColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadePlatformInOutRoutine());
        }
    }

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
