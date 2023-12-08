using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Assign your panel in the Inspector
    public MonoBehaviour scriptA; // Assign your ScriptA in the Inspector
    public MonoBehaviour scriptB; // Assign your ScriptB in the Inspector

    private bool isPaused = false;

    void Start()
    {
        // Ensure the panel is initially hidden
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (pausePanel != null)
        {
            // Toggle the visibility of the panel
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);

            // Pause or resume the game based on the panel's visibility
            Time.timeScale = isPaused ? 0f : 1f;

            // Toggle the first script
            if (scriptA != null)
            {
                scriptA.enabled = !isPaused;
            }

            // Toggle the second script
            if (scriptB != null)
            {
                scriptB.enabled = !isPaused;
            }

            // Set the cursor visibility and locking state
            Cursor.visible = !isPaused;
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
