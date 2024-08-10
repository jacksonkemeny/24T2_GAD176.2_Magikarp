using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPickupTextManager : MonoBehaviour
{
 
    public TextMeshProUGUI myText;
    private bool isPopupActive = false;


    // Start is called before the first frame update
    void Start()
    {

        if (myText == null)
        {
            Debug.LogError("TextMeshProUGUI component 404");
        }
        else
        {
            myText.gameObject.SetActive(false);  // Ensure the UI is inactive at the start
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPopup(string message, float displayDuration)
    {
        if (!isPopupActive)
        {
            isPopupActive = true;  
            myText.text = message;  
            myText.gameObject.SetActive(true);
            StartCoroutine(HidePopupAfterDelay(displayDuration));
        }
    }

    private IEnumerator HidePopupAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myText.gameObject.SetActive(false);  
        isPopupActive = false; 
    }

    public void AddText(string textToAdd)
    {
        myText.text += "\n" + textToAdd;
    }
   
    public void RemoveText(string textToRemove)
    {
        myText.text = "" + textToRemove;
    }

}
