using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public ParticleSystem blood;
    bool touch = false;
    
    void isTouched()
    {
        Instantiate(blood, transform.position, transform.rotation);
        touch = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PickUp_Damaged")
        {
            isTouched();
            gameObject.SetActive(false);
            print("collision");
            touch = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {

     
    }

    // Update is called once per frame
    void Update()
    {

    }
}
