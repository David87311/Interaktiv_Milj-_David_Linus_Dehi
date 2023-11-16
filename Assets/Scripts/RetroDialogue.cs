using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetroDialogue : MonoBehaviour
{
    public Text dialogueText;
    public float typingSpeed = 0.05f; // Adjust the typing speed as needed
    public float disableTime = 6f;
    private string fullText;

    void Start()
    {
        // Get the full text from the Text component
        fullText = dialogueText.text;
        // Clear the text to start typing
        dialogueText.text = "";
        StartCoroutine(TypeText());
        StartCoroutine(DisableAfterTimeRoutine());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            // Append the next letter to the displayed text
            dialogueText.text += letter;
            // Wait for a short duration before displaying the next letter
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    IEnumerator DisableAfterTimeRoutine()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(disableTime);

        // Disable the GameObject
        dialogueText.enabled = false;

    }


}
