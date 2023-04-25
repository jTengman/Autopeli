using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LaughingLogic : MonoBehaviour
{
    public AudioSource laugh;
    int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (counter == 5)
        {
            Instantiate(laugh, transform.position, transform.rotation);
            counter = 0;
        }
        else
        {
            counter++;
        }

    }

}
