using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class NPCInteract : MonoBehaviour
{
    public Text dialogueText; // Reference to the Text UI element
    public float textSpeed = 0.05f; // Speed at which the text is displayed

    private ArrayList dialogueList = new ArrayList(); // List to store dialogue text
    private int currentIndex = 0; // Index of the current dialogue text
    public float interactionDistance = 3f;
    public LayerMask npcLayer;

    private void Start()
    {
        // Initialize the dialogue list with your dialogue text
        dialogueList.Add("Hello, adventurer!");
        dialogueList.Add("Welcome to the village.");
        dialogueList.Add("How can I help you?");
    }

    private void Update()
    {
        ShowNextText();
    }

    private void ShowNextText()
    {
        // Check if there is more dialogue to display
        if (currentIndex < dialogueList.Count)
        {
            // Display the current dialogue text
            StartCoroutine(DisplayText((string)dialogueList[currentIndex]));

            // Move to the next dialogue text
            currentIndex++;
        }
        else
        {
            // End of dialogue, you can close the dialogue box or perform other actions
            Debug.Log("End of dialogue");
        }
    }

    private IEnumerator DisplayText(string text)
    {
        // Clear existing text
        dialogueText.text = "";

        // Display text character by character
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
