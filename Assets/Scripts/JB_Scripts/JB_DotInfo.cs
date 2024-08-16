using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class JB_DotInfo : MonoBehaviour
{
   
    public GameObject TextUi;

    // Start is called before the first frame update
    void Start()
    {
      //  SetFalse();
    }
    public void SetActive()
    {
        Debug.Log("SetActive! from " + gameObject.name);
        TextUi.gameObject.SetActive(true); // Set to true to show, false to hide
    }

    public void SetFalse()
    {
        Debug.Log("SetFalse! from " + gameObject.name);
        TextUi.gameObject.SetActive(false); // Set to true to show, false to hide
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
