using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    //Variables de estado general del jugador
    public bool isAim;
    public bool isShooting;
    public bool isDead;
    
    void Update()
    {
        //Acción de apuntado
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            isAim = true;
        }
        else isAim = false;
    }
}
