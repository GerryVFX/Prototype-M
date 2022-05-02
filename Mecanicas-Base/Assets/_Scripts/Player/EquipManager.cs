using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    //Variable para almacenar los equipos
    public int n_equip;
    public int n_equip2;
    public GameObject gun;
    public GameObject flashlight;
    public GuiControl statusMenu;
    public GameObject[] equipment;

    //Selector de equipo activo
    GuiControl equipSelection;
    
    
    void Start()
    {
        //Declarar al selector de equipo
        equipSelection = FindObjectOfType<GuiControl>();
        
    }

    
    void Update()
    {
        //Detectar la activación del equipo
        Equip();
    }

    //Activar y desactivar equipo según su slección
    void Equip()
    {
        //Para pistola
        if (equipment[0].tag == "EquipA")
        {
            n_equip = 0;
            if (equipSelection.equipA)
            {

                equipment[0].SetActive(true);
            }
            else
            {

                equipment[0].SetActive(false);
            }
        }
        

        if (equipment[0].tag == "EquipB")
        {
            n_equip2 = 0;
            if (equipSelection.equipB)
            {

                equipment[0].SetActive(true);
            }
            else
            {

                equipment[0].SetActive(false);
            }

        }
        

        //Para linterna
        if (equipment[1].tag == "EquipA")
        {
            n_equip = 1;
            if (equipSelection.equipA)
            {

                equipment[1].SetActive(true);
            }
            else equipment[1].SetActive(false);
        }
        

        if (equipment[1].tag == "EquipB")
        {
            n_equip2 = 1;
            if (equipSelection.equipB)
            {

                equipment[1].SetActive(true);
            }
            else equipment[1].SetActive(false);
        }

        if (equipment[2].tag == "EquipA")
        {
            n_equip = 2;
            if (equipSelection.equipA)
            {

                equipment[2].SetActive(true);
            }
            else equipment[2].SetActive(false);
        }


        if (equipment[2].tag == "EquipB")
        {
            n_equip2 = 2;
            if (equipSelection.equipB)
            {

                equipment[2].SetActive(true);
            }
            else equipment[2].SetActive(false);
        }
    }
}
