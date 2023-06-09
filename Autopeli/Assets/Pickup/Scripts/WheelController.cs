using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;
    [SerializeField] GameObject CenterOfMass;
    Rigidbody rb;

    public float acceleration = 300f;
    public float maxSpeed = 20f;

    public float breakingForce = 500f;
    public float maxTurnAngle = 15f;
    

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = CenterOfMass.transform.localPosition;
    }



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            currentAcceleration = 0f;
            currentBreakForce = 0f;
            currentTurnAngle = 0f;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        Braking();

        // Acceleration with rear wheels
        if(rb.velocity.magnitude > maxSpeed || rb.velocity.magnitude < -maxSpeed)
        {
            backRight.motorTorque = 0f;
            backLeft.motorTorque = 0f; 
        }
        else
        {
            backRight.motorTorque = currentAcceleration;
            backLeft.motorTorque = currentAcceleration;
        }




        //Steering
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        //P�ivitet��n py�rien suunnat
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);
    }

    private void Braking()
    {
        if (currentAcceleration < -100f && transform.InverseTransformDirection(rb.velocity).z > 0.5) 
        {

            currentBreakForce = breakingForce;
            backRight.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;
            frontLeft.brakeTorque = currentBreakForce;
            frontRight.brakeTorque = currentBreakForce;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakingForce;
            backRight.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;
        }
        else
        {
            currentBreakForce = 0;
            backRight.brakeTorque = currentBreakForce;
            backLeft.brakeTorque = currentBreakForce;
            frontLeft.brakeTorque = currentBreakForce;
            frontRight.brakeTorque = currentBreakForce;
        }
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);
        trans.position = position;
        trans.rotation = rotation;
    }

}
