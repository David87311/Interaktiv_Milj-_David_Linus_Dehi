using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public ToggleCarCam CarCam;
    public CameraFollow CarCamFollow;

    private void Awake()
    {
        CarCamFollow = GameObject.Find("CarCam").GetComponent<CameraFollow>();
        CarCamFollow.carTransform = transform;
        CarCam = GameObject.Find("Player").GetComponent<ToggleCarCam>();
        CarCam.interactionCollider = transform.GetChild(3).GetComponent<Collider>();
        CarCam.CarControls = GetComponent<PrometeoCarController>();
        CarCam.CarExit = transform.GetChild(4).GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
