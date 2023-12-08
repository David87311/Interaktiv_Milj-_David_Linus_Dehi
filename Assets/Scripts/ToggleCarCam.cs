using UnityEngine;

public class ToggleCarCam : MonoBehaviour
{
    public Collider interactionCollider; // Assign the collider in the inspector

    public MonoBehaviour FirstPersonScript; // Assign the first player script in the inspector
    public MonoBehaviour CarCamScript; // Assign the second player script in the inspector

    public Camera FirstPersonCam; // Assign the first camera script in the inspector
    public Camera CarCam; // Assign the second camera script in the inspector

    public MonoBehaviour MovementPlayer;
    public MonoBehaviour CarControls;


    // public MonoBehaviour CarControl;

    public GameObject Player;

    public Transform CarExit;

    private bool isScript1Active = true;

    private bool InCar = false;


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

        if (InCar == true) 
        {
            transform.position = CarExit.transform.position; // Min gubbe följer med bilen.

            // Disable the renderer

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
            //Inte i bilen

            MovementPlayer.enabled = true;
            CarControls.enabled = false;

            FirstPersonScript.enabled = true;
            CarCamScript.enabled = false;
            FirstPersonCam.enabled = true;
            CarCam.enabled = false;
            InCar = false;
            Player.GetComponent<Renderer>().enabled = true;

            CarExit.parent.GetComponent<AudioSource>().Stop();


        }
        else
        {
            //I bilen

            MovementPlayer.enabled=false;
            CarControls.enabled = true;
            FirstPersonScript.enabled = false;
            CarCamScript.enabled = true;
            FirstPersonCam.enabled = false;
            CarCam.enabled = true;
            InCar = true;
            Player.GetComponent<Renderer>().enabled = false;

            CarExit.parent.GetComponent<AudioSource>().Play();

        }

        isScript1Active = !isScript1Active;
    }
}
