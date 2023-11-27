using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Text NPCdialogueText; // Reference to the Text UI element
    public float textSpeed = 0.05f; // Speed at which the text is displayed

    private ArrayList dialogueList = new ArrayList(); // List to store dialogue text
    private int currentIndex = 0; // Index of the current dialogue text
    public float disableTime = 4f;

    public float interactionDistance = 2f;
    public LayerMask npcLayer;

    private void Start()
    {
        // Initialize the dialogue list with your dialogue text
        dialogueList.Add("Hello, my Name is John!");
        dialogueList.Add("Welcome to the village.");
        dialogueList.Add("How can I help you?");
    }

    private void Update()
    {
            // Check for player input to interact
        if (Input.GetKeyDown(KeyCode.E))
        {
                // Raycast to check if there's an NPC in front of the player
             RaycastHit hit;
             if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, npcLayer))
                {
                    // Check if the object hit has the "NPC" layer
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("NPC"))
                    {
                        // NPC is hit, you can perform NPC interaction here
                        ShowNextText();
                        Debug.Log("Du ser ingen text, men det fungerar!");
                    }
             }
        }
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
        NPCdialogueText.text = "";

        // Display text character by character
        foreach (char c in text)
        {
            NPCdialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    IEnumerator DisableAfterTimeRoutine()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(disableTime);

        // Skip to the next the Text dialogue
        currentIndex++;

    }
}
