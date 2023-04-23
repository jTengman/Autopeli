using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    Vector3 spawnPoint;

   
    void Start()
    {
        spawnPoint = gameObject.transform.position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            gameObject.transform.position = spawnPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CheckPoint"))
        {
            spawnPoint = other.gameObject.transform.position;
            Destroy(other.gameObject);
        }
    }
}
