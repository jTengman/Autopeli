using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Star : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = other.GetComponent<GameManager>();
        gm.StarCollected();
        gameObject.SetActive(false);
    }
}
