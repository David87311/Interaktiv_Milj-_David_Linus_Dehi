using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    
    public Text[] textArray;
    private float disableTime = 5f;
    public float typingSpeed = 0.05f; // Adjust the typing speed as needed
    private string fullText;

    void Start()
    {
        fullText = textArray[0].text; 
        textArray[0].text = "";


        if (textArray != null && textArray.Length > 0)
        {
            textArray[0].text = "";
            textArray[1].text = "";
        }
        else
        {
            Debug.LogError("Text array is not assigned or is empty. Please assign Text objects in the Inspector.");
        }

    }

    public void OnInteraction()
    {
        StartCoroutine(TypeText());
        StartCoroutine(DisableAfterTimeRoutine());
    }
    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            // Append the next letter to the displayed text
            textArray[0].text += letter;
            // Wait for a short duration before displaying the next letter
            yield return new WaitForSeconds(typingSpeed);
        }
    }
   

    IEnumerator DisableAfterTimeRoutine()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(disableTime);

        // Disable the GameObject
        textArray[0].enabled = false;

    }


}

