using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiControl : MonoBehaviour
{
    //Variables del men� de status en men� r�pido
    public GameObject status;
    public GameObject selectA;
    public GameObject selectB;

    //Para activar erquipo en jugador
    PlayerMain actual_Equip;

    //Para activar el menu de equipo 
    public GameObject equip_Menu, invent_Menu, file_Menu;
    public bool inMenu;


    void Start()
    {
        //Conexi�n con el player
        actual_Equip = FindObjectOfType<PlayerMain>();
    }

    private void Update()
    {

        //Abrir men� de equipo
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipMenu();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
           InventMenu();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            FileMenu();
        }
    }

    //Activaci�n del menu de status por tiempo y cambia equipo
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

    //Metodo para activar brevemente el men� r�pido
    public void EnableStatus()
    {
        StartCoroutine(ActiveStatus());
    }

    public void EquipMenu()
    {
        if (!inMenu)
        {
            inMenu = true;
            equip_Menu.tag = "ActiveMenu";
            equip_Menu.SetActive(true);
            status.SetActive(true);
        }
        else
        {
            if(equip_Menu.tag != "ActiveMenu")
            {
                invent_Menu.SetActive(false);
                invent_Menu.tag = "InactiveMenu";
                file_Menu.SetActive(false);
                file_Menu.tag = "InactiveMenu";
                equip_Menu.SetActive(true);
                equip_Menu.tag = "ActiveMenu";
            } 
            
            else if (equip_Menu.tag == "ActiveMenu")
            {
                inMenu = false;
                equip_Menu.tag = "InactiveMenu";
                equip_Menu.SetActive(false);
                status.SetActive(false);
            }
        }
    }

    public void InventMenu()
    {
        if (!inMenu)
        {
            inMenu = true;
            invent_Menu.tag = "ActiveMenu";
            invent_Menu.SetActive(true);
            status.SetActive(true);
        }
        else
        {
            if (invent_Menu.tag != "ActiveMenu")
            {
                equip_Menu.SetActive(false);
                equip_Menu.tag = "InactiveMenu";
                file_Menu.SetActive(false);
                file_Menu.tag = "InactiveMenu";
                invent_Menu.SetActive(true);
                invent_Menu.tag = "ActiveMenu";
            }

            else if (invent_Menu.tag == "ActiveMenu")
            {
                inMenu = false;
                invent_Menu.tag = "InactiveMenu";
                invent_Menu.SetActive(false);
                status.SetActive(false);
            }
        }
    }

    public void FileMenu()
    {
        if (!inMenu)
        {
            inMenu = true;
            file_Menu.tag = "ActiveMenu";
            file_Menu.SetActive(true);
            status.SetActive(true);
        }
        else
        {
            if (file_Menu.tag != "ActiveMenu")
            {
                invent_Menu.SetActive(false);
                invent_Menu.tag = "InactiveMenu";
                equip_Menu.SetActive(false);
                equip_Menu.tag = "InactiveMenu";
                file_Menu.SetActive(true);
                file_Menu.tag = "ActiveMenu";
            }

            else if (file_Menu.tag == "ActiveMenu")
            {
                inMenu = false;
                file_Menu.tag = "InactiveMenu";
                file_Menu.SetActive(false);
                status.SetActive(false);
            }
        }
    }

}
