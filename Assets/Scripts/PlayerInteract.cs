using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2.5f);

            if (hit)
            {
                Interact interact;
                hitInfo.transform.TryGetComponent<Interact>(out interact);

                if (interact != null)
                {
                    interact.OnInteraction();
                }
                else
                {
                    Debug.Log("Not Interactable");
                }
            }
        }

    }
}
