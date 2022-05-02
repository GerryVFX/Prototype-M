using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour
{
    //Variables de estado general del jugador
    public bool isAim;
    public bool isShooting;
    public bool isDead;

    //Salud del jugador
    [SerializeField]
    float life = 3;
    public Image lifebar;
    public Sprite[] lifeStatus;
    
    void Update()
    {
        //Acción de apuntado
        if (Input.GetKey(KeyCode.Joystick1Button5)||Input.GetButton("Fire2"))
        {
            isAim = true;
        }
        else isAim = false;

        //Estado de salud
        switch (life)
        {
            case 0:
                lifebar.sprite = lifeStatus[0];
                return;
            case 1:
                lifebar.sprite = lifeStatus[0];
                return;
            case 2:
                lifebar.sprite = lifeStatus[1];
                return;
            case 3:
                lifebar.sprite = lifeStatus[2];
                return;
        }
    }
}
