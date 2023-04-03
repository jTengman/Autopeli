using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public float minSpeed,maxSpeed;
    private float currentSpeed;

    private Rigidbody rb;
    private AudioSource carSound;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;
    // Start is called before the first frame update
    void Start()
    {
        carSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CarSound();
        
    }

    void CarSound()
    {
        currentSpeed = rb.velocity.magnitude;
        pitchFromCar = rb.velocity.magnitude / 20f;

        if(currentSpeed < minSpeed)
        {
            carSound.pitch = minPitch;

        }

        if(currentSpeed > minSpeed && currentSpeed < maxSpeed) 
        {
            carSound.pitch = minPitch + pitchFromCar;
        }

        if (currentSpeed > maxSpeed)
        {
            carSound.pitch = maxPitch;

        }
    }
}
