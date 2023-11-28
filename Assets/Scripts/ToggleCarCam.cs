using UnityEngine;

public class ToggleCarCam : MonoBehaviour
{
    public Collider interactionCollider; // Assign the collider in the inspector

    public MonoBehaviour FirstPersonScript; // Assign the first player script in the inspector
    public MonoBehaviour CarCamScript; // Assign the second player script in the inspector

    public Camera FirstPersonCam; // Assign the first camera script in the inspector
    public Camera CarCam; // Assign the second camera script in the inspector

    public MonoBehaviour MovementPlayer;
    // public MonoBehaviour CarControl;


    public GameObject PlayerCharacter;

    private bool isScript1Active = true;


    public void Start()
    {
        CarCam.enabled = false;
    }

    void Update()
    {
        if (IsPlayerInInteractionArea() && Input.GetKeyDown(KeyCode.E))
        {
            ToggleScripts();
        }
    }

    bool IsPlayerInInteractionArea()
    {
        return interactionCollider != null && interactionCollider.bounds.Contains(transform.position);
    }

    void ToggleScripts()
    {
        if (isScript1Active)
        {
            MovementPlayer.enabled = true;
            FirstPersonScript.enabled = true;
            CarCamScript.enabled = false;
            FirstPersonCam.enabled = true;
            CarCam.enabled = false;
            Debug.Log("Player Script 1 disabled, Player Script 2 enabled. Camera Script 1 disabled, Camera Script 2 enabled.");
        }
        else
        {
            MovementPlayer.enabled=false;
            FirstPersonScript.enabled = false;
            CarCamScript.enabled = true;
            FirstPersonCam.enabled = false;
            CarCam.enabled = true;
            Debug.Log("Player Script 1 enabled, Player Script 2 disabled. Camera Script 1 enabled, Camera Script 2 disabled.");
        }

        isScript1Active = !isScript1Active;
    }
}
