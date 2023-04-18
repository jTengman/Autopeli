using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = other.GetComponent<GameManager>();
        gm.LevelComplete();
    }
}
