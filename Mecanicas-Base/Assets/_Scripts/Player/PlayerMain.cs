using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public bool isAim;
    public bool isShooting;
    public bool isDead;

    

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            isAim = true;
        }
        else isAim = false;
    }
}
