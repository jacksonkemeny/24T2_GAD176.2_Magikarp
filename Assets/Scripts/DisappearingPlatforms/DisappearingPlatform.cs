using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Color platformColor;
    [SerializeField] private float fadeSpeed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Transform>();
        platformColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private IEnumerator FadePlatformInOutRoutine()
    {
        while (platformColor.a > 0)
        {
            platformColor.a = Mathf.MoveTowards(platformColor.a, 0, Time.deltaTime * fadeSpeed);
            yield return null;
        }

        if (platformColor.a == 0)
        {
            platform.gameObject.SetActive(false);
            yield return null;
        }

        yield return new WaitForSeconds(3);

        while (platformColor.a < 1)
        {
            platformColor.a = Mathf.MoveTowards(platformColor.a, 1, Time.deltaTime * fadeSpeed);
        }

        yield return null;
    }
}
