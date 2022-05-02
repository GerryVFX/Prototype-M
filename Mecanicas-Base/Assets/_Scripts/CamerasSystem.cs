using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; //Se ocupa libreria Cinemachine

public class CamerasSystem : MonoBehaviour
{
    //C�mara virtual activa
    CinemachineVirtualCamera currentCamera;

    //Camara objetivo al trigger
    public CinemachineVirtualCamera targetCamera;

    //Detecci�n de collider del jugador 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraChange();
        }
    }

    //Cambio de c�maras
    void CameraChange()
    {
        //Detecci�n de la c�mara activa
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

        //Nueva asignaci�n de c�mara por prioridad
        if (currentCamera != targetCamera || currentCamera == null)
        {
            targetCamera.tag = "CurrentCamera";
            targetCamera.Priority = 100;

            currentCamera.tag = "InactiveCamera";
            currentCamera.Priority = 99;
        }
    }
}
