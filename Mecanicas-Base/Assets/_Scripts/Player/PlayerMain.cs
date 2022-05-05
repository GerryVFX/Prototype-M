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
    public bool medical_UsefullA;
    public bool medical_UsefullB;
    public bool canReloadA;
    public bool canReloadB;

    //Equipo del jugador
    public bool equipA;
    public bool equipB;
    [SerializeField]
    GameObject[] all_Equip;
    EquipManager myEquip;
    GuiControl statusMenu;

    SoundsSystem my_sounds;
   


    private void Start()
    {
        //Conexión con el inventario y menús
        myEquip = FindObjectOfType<EquipManager>();
        statusMenu = FindObjectOfType<GuiControl>();
        my_sounds = FindObjectOfType<SoundsSystem>();
    }

    void Update()
    {
        //Revisar que equipos estan en el menú rápido
        EquipAsign();

        //Acción de apuntado
        if (Input.GetKey(KeyCode.Joystick1Button5)||Input.GetButton("Fire2"))
        {
            isAim = true;
        }
        else isAim = false;

        //Activar menú ráido brevemente y cambiar de equipo activo
        if (Input.GetKeyDown(KeyCode.C) && !statusMenu.inMenu)
        {
            statusMenu.EnableStatus();
            statusMenu.SelectorEquip();
            SwitchEquip();
        }

        //Cambiar equipo activo dentro del menú de equipo
        if (Input.GetKeyDown(KeyCode.C) && statusMenu.inMenu)
        {
            statusMenu.SelectorEquip();
            SwitchEquip();
        }

        //Usar medicamento
        if (myEquip.equipA == "MEDICAL" || myEquip.equipB == "MEDICAL")
        {
            if (medical_UsefullA||medical_UsefullB)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    UsingMedical();
                }
            }
           
        }

        //Recargar pistola
        if (canReloadA || canReloadB)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Reload();
            }
        }

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

    //Activar prefab de equipo con respecto al equipo  activo
    void EquipAsign()
    {
        if (equipA)
        {
            if (myEquip.equipA == "GUN")
            {
                all_Equip[0].SetActive(true);
                canReloadA = true;
                
            }              
            else all_Equip[0].SetActive(false);
            if (myEquip.equipA == "FLASH") all_Equip[1].SetActive(true);
            else all_Equip[1].SetActive(false);
            if (myEquip.equipA == "KNIFE") all_Equip[2].SetActive(true);
            else all_Equip[2].SetActive(false);
            if (myEquip.equipA == "MEDICAL") medical_UsefullA = true;
            medical_UsefullB = false;
            canReloadB = false;

        }

        if (equipB)
        {
            if (myEquip.equipB == "GUN")
            {
                all_Equip[0].SetActive(true);
                canReloadB = true;
                
            }               
            else all_Equip[0].SetActive(false);
            if (myEquip.equipB == "FLASH")
            {
                all_Equip[1].SetActive(true);
                medical_UsefullA = false;
                canReloadA = false;
            }
                
            else all_Equip[1].SetActive(false);
            if (myEquip.equipB == "KNIFE")
            {
                all_Equip[2].SetActive(true);
                medical_UsefullA = false;
                canReloadA = false;
            }
                
            else all_Equip[2].SetActive(false);
            if (myEquip.equipB == "MEDICAL")
            {
                medical_UsefullB = true;
                canReloadA = false;
            }
                
            medical_UsefullA = false;
            canReloadA = false;
        }
    }

    //Cambiar de equipo activo
    void SwitchEquip()
    {
        if (equipA)
        {
            equipA = false;
            equipB = true;
        }
        else if (equipB)
        {
            equipB = false;
            equipA = true;
        }
    }

    public void UsingMedical()
    {
        if (myEquip.medical_reserv > 0)
        {
            my_sounds.Heal();
            life += 3;
            myEquip.medical_reserv -= 1;

            if (myEquip.equipA == "MEDICAL" && myEquip.medical_reserv == 0)
            {
                myEquip.equipA = "Empty";
            }
            if (myEquip.equipB == "MEDICAL" && myEquip.medical_reserv == 0)
            {
                myEquip.equipB = "Empty";
            }
            if (life > 3)
            {
                life = 3;
            }
        }
    }

    public void Reload()
    {
        if (myEquip.bullets_reserv > 0)
        {
            my_sounds.Reload();
            int maxReload = 15;
            maxReload -= myEquip.bullets_length;
            myEquip.bullets_length += maxReload;
            myEquip.bullets_reserv -= maxReload;
        }
    }
}
