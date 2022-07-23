using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleCarController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> allWheels;
    private float rpm;
    private int wheelsOnGround;
        
    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;
    private float speed;

    public WheelCollider frontDriverW, fronPassengerW;
    public WheelCollider rearDriverW, rearPassangerW;
    public Transform frontDriverT, fronPassengerT;
    public Transform rearDriverT, rearPassangerT;
    public float maxSteerAngle = 30;
    public float motorForce;

    public string horizontalInput;
    public string verticalInput;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis(horizontalInput);
        m_verticalInput = Input.GetAxis(verticalInput);
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        fronPassengerW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        frontDriverW.motorTorque += m_verticalInput * motorForce;
        fronPassengerW.motorTorque += m_verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(fronPassengerW, fronPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassangerW, rearPassangerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void SpeedTextUpdate()
    {
        speed = Mathf.Round(frontDriverW.motorTorque * 2.237f);
        speedometerText.SetText("Speed: " + speed + " mph");
    }

    private void RpmTextUpdate()
    {
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }
    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
            SpeedTextUpdate();
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }

        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        return false;
    }




    // He said that he names "_" for and "m_" is for entire class.

}
