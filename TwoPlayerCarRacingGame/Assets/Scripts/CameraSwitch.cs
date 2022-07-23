using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    //TODO: Make both of the cameras active at the same time

    public GameObject cam1;
    public GameObject cam2;

    // Update is called once per frame
    void Update()
    {
        
        // Input: 1, activate cam1
        if(Input.GetButtonDown("1Key"))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }

        // Input: 2, activate cam2
        if (Input.GetButtonDown("2Key"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }

    }
}
