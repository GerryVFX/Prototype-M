using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Map : MonoBehaviour
{
    //Para el uso del zoom 
    public Transform player;
    Vector3 camPosition;
    GUIControl zoomDetection;

    private void Start()
    {
        zoomDetection = FindObjectOfType<GUIControl>();
        camPosition = transform.position;
        
    }
    private void Update()
    {
        // Comprobación del zoom
        if (zoomDetection.inZoom == false)
        {
            transform.position = camPosition;
        }
    }

    //Para evitar que el mapa se mueva con el jugador
    private void LateUpdate()
    {
        if (zoomDetection.inZoom)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
    }
}
