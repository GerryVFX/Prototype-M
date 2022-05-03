using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiControl : MonoBehaviour
{
    //Variables del menú de status en menú rápido
    public GameObject status;
    public GameObject selectA;
    public GameObject selectB;

    //Para activar erquipo en jugador
    PlayerMain actual_Equip;

    //Para activar el menu de equipo 
    public GameObject equip_Menu;
    public bool inMenu;


    void Start()
    {
        //Conexión con el player
        actual_Equip = FindObjectOfType<PlayerMain>();
    }

    private void Update()
    {

        //Abrir menú de equipo
        if (!inMenu)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inMenu = true;
                equip_Menu.SetActive(true);
                status.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inMenu = false;
                equip_Menu.SetActive(false);
                status.SetActive(false);
            }
        }
    }

    //Activación del menu de status por tiempo y cambia equipo
    public IEnumerator ActiveStatus()
    {
        status.SetActive(true);
        yield return new WaitForSeconds(2);
        status.SetActive(false);
    }

    //Cambiar marca de equipo selccionado
    public void SelectorEquip()
    {
        if (actual_Equip.equipA) selectB.SetActive(true);
        else selectB.SetActive(false);
        if (actual_Equip.equipB) selectA.SetActive(true);
        else selectA.SetActive(false);
    }

    //Metodo para activar brevemente el menú rápido
    public void EnableStatus()
    {
        StartCoroutine(ActiveStatus());
    }

}
