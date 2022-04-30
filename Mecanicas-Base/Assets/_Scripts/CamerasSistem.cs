using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamerasSistem : MonoBehaviour
{
    CinemachineVirtualCamera currentCamera;
    public CinemachineVirtualCamera targetCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraChange();
        }
    }

    void CameraChange()
    {
        if (GameObject.FindGameObjectWithTag("CurrentCamera") != null)
        {
            if (GameObject.FindGameObjectWithTag("CurrentCamera").GetComponent<CinemachineVirtualCamera>() != null)
            {
                currentCamera = GameObject.FindGameObjectWithTag("CurrentCamera").GetComponent<CinemachineVirtualCamera>();
            }
        }
        else
        {
            currentCamera = null;
        }
        if (currentCamera != targetCamera || currentCamera == null)
        {
            targetCamera.tag = "CurrentCamera";
            targetCamera.Priority = 100;

            currentCamera.tag = "InactiveCamera";
            currentCamera.Priority = 99;
        }
    }
}
