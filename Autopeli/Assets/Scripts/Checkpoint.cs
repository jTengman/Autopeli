using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    Vector3 spawnPoint;
    Quaternion spawnRotation;

   
    void Start()
    {
        spawnPoint = gameObject.transform.position;
        spawnRotation = gameObject.transform.rotation;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            gameObject.transform.position = spawnPoint;
            gameObject.transform.rotation = spawnRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            spawnPoint = other.gameObject.transform.position;
            spawnRotation = other.gameObject.transform.rotation;
            Destroy(other.gameObject);
        }
    }
}
