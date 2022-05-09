using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Map : MonoBehaviour
{
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
        if (zoomDetection.inZoom == false)
        {
            transform.position = camPosition;
        }
    }

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
