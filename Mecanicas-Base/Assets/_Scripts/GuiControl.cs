using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiControl : MonoBehaviour
{
    SoundsSystem  menu_Sounds;

    //Variables del menú de status en menú rápido
    public GameObject status;
    public GameObject selectA;
    public GameObject selectB;

    //Para activar erquipo en jugador
    PlayerMain actual_Equip;

    //Para activar el menu de equipo 
    public GameObject[] equip_Actions;
    public GameObject equip_Menu, invent_Menu, file_Menu;
    public bool inMenu;




    void Start()
    {
        //Conexión con el player
        actual_Equip = FindObjectOfType<PlayerMain>();
        menu_Sounds = FindObjectOfType<SoundsSystem>();
    }

    private void Update()
    {

        //Abrir menú de equipo
        if (Input.GetKeyDown(KeyCode.E))
        {
            menu_Sounds.SoundMenu();
            EquipMenu();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            menu_Sounds.SoundMenu();
            InventMenu();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            menu_Sounds.SoundMenu();
            FileMenu();
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


    public void ActionsGun()
    {        
            equip_Actions[0].SetActive(true);   
    }
    public void DesactiveActionGun()
    {       
            equip_Actions[0].SetActive(false);   
    }
    public void ActionsFlash()
    {
        equip_Actions[1].SetActive(true);
    }
    public void DesactiveActionFlash()
    {
        equip_Actions[1].SetActive(false);
    }
    public void ActionsKnife()
    {
        equip_Actions[2].SetActive(true);
    }
    public void DesactiveActionKnife()
    {
        equip_Actions[2].SetActive(false);
    }
}
