using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public ParticleSystem blood;
    public AudioSource HittingSound;
    void isTouched()
    {
        Instantiate(blood, transform.position, transform.rotation);
        Instantiate(HittingSound, transform.position, transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PickUp_Damaged")
        {
            GameManager gm = other.GetComponent<GameManager>();
            gm.InvaderHit();
            isTouched();
            gameObject.SetActive(false);
            print("collision");
        }

    }
}
