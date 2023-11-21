using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 2f; // The distance at which the player can interact with the object
    private ArrayList dialogueJohn = new ArrayList(); // List to store dialogue text
    private int currentIndex = 0; // Index of the current dialogue text
    public Text dialogueText; // Reference to the Text UI element
    public float textSpeed = 0.05f; // Speed at which the text is displayed

    private void Start()
    {
        // Initialize the dialogue list with your dialogue text
        dialogueJohn.Add("Hello, my name is John!");
        dialogueJohn.Add("Welcome to the City.");

    }

    private void Update()
    {
        // Check for player input to interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Raycast to check if there's an object with the "NPC" tag in front of the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                // Check if the object has the tag "NPC"
                if (hit.collider.CompareTag("NPC"))
                {
                    // Perform interaction with the NPC (you can add your logic here)
                    Debug.Log("Interacting with NPC:");
                    ShowNextText();
                } 
            }
                
        }
    }

    private void ShowNextText()
    {
        // Check if there is more dialogue to display
        if (currentIndex < dialogueJohn.Count)
        {
            // Display the current dialogue text
            StartCoroutine(DisplayText((string)dialogueJohn[currentIndex]));

            // Move to the next dialogue text
            currentIndex++;
        }
        else
        {
            // End of dialogue, you can close the dialogue box or perform other actions
            Debug.Log("End of dialogue");
            dialogueText.enabled = false;
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

