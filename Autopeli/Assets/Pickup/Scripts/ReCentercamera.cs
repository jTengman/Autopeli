using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ReCentercamera : MonoBehaviour
{
    private CinemachineFreeLook camera1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera1 = GetComponent<CinemachineFreeLook>();
        camera1.m_RecenterToTargetHeading.m_enabled = true;
        camera1.m_YAxisRecentering.m_enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("ReCenterCamera") == 1)
        {
            camera1.m_RecenterToTargetHeading.m_enabled = true;
            camera1.m_YAxisRecentering.m_enabled=true;
        }
        else
        {
            camera1.m_RecenterToTargetHeading.m_enabled = false;
            camera1.m_YAxisRecentering.m_enabled = false;
        }
    }
}
