using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Numerics;

public class TextDisplay : MonoBehaviour
{
    public TextMeshProUGUI myText;


    // Start is called before the first frame update
    void Start()
    {
      
        //fetches the correct object.
        myText = GetComponent<TextMeshProUGUI>();
        myText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {




    }

    //Adds new text
    public void AddText(string textToAdd)
    {
        myText.text += "\n" + textToAdd;
    }
    //Clears text 
    public void RemoveText(string textToRemove)
    {
        myText.text = "" + textToRemove;
    }

    //Coroutine that sets the text panel inactive after a certain period of time passes. 
    public IEnumerator ShowTextForDuration(string textToShow, float duration)
    {
        myText.text = textToShow;
        myText.gameObject.SetActive(true); 

        yield return new WaitForSeconds(duration);

        myText.gameObject.SetActive(false); 
    }
}
