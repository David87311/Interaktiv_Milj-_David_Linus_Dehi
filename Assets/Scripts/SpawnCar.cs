using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(car,transform.position,car.transform.rotation);
    }
}
