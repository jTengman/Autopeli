using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimes : MonoBehaviour
{
    public float GoldTime;
    public float SilverTime;
    public float BronzeTime;
    public float PBTime;

    public void setPB(float PB)
    {
        PBTime = PB;
    }
}
