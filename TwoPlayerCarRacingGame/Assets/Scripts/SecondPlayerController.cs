using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondPlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedometerText;
    private float speed = 20;
    private float turnSpeed = 100;
    private float horizontalInput;
    private float forwardInput;
    
    private void SpeedometerTextUpdate()
    {
        speedometerText.SetText("Speed: " + speed * 3.6f + " mph");
    }

    // Update is called once per frame
    void Update()
    {
        // Manage inputs from user
        forwardInput = Input.GetAxis("_vertical");
        horizontalInput = Input.GetAxis("_horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        SpeedometerTextUpdate();
    }
}
