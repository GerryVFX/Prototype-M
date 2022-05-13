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
    public bool canShootA;
    public bool canShootB;

    //Equipo del jugador
    public bool equipA;
    public bool equipB;
    [SerializeField]
    GameObject[] all_Equip;
    EquipManager myEquip;
    GUIControl statusMenu;

    //Gesti�n de sonidos dentro de la escena
    SoundsSystem my_sounds;

    private void Start()
    {
        //Conexi�n con el inventario y men�s
        myEquip = FindObjectOfType<EquipManager>();
        statusMenu = FindObjectOfType<GUIControl>();
        my_sounds = FindObjectOfType<SoundsSystem>();
    }

    void Update()
    {
        //Revisar que equipos estan en el men� r�pido
        EquipAsign();

        //Acci�n de apuntado
        if(myEquip.equipA!="Empty"|| myEquip.equipB != "Empty")
        {
            if (Input.GetKey(KeyCode.Joystick1Button5) || Input.GetButton("Fire2"))
            {
                isAim = true;
            }
            else isAim = false;
        }
        
        //Activar men� r�ido brevemente y cambiar de equipo activo
        if (Input.GetKeyDown(KeyCode.C) && !statusMenu.inMenu)
        {
            statusMenu.EnableStatus();
            statusMenu.SelectorEquip();
            SwitchEquip();
        }

        //Cambiar equipo activo dentro del men� de equipo
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
        if (equipA) //Para el panel A
        {
            if (myEquip.equipA == "GUN") //Pistola
            {
                all_Equip[0].SetActive(true);
                canReloadA = true;
                canShootA = true;   
            }
            else
            {
                all_Equip[0].SetActive(false);
            }              

            if (myEquip.equipA == "FLASH") //Linterna
            {
                all_Equip[1].SetActive(true);
                canReloadA = false;
                canShootA = false;
            }           
            else all_Equip[1].SetActive(false);

            if (myEquip.equipA == "KNIFE") //Cuchillo
            {
                all_Equip[2].SetActive(true);
                canReloadA = false;
                canShootA = false;
            }     
            else all_Equip[2].SetActive(false);

            if (myEquip.equipA == "MEDICAL") //Equipo m�dico Full
            {
                medical_UsefullA = true;
                canReloadA = false;
                canShootA = false;
            }        
            medical_UsefullB = false;
            canReloadB = false;
            canShootB = false;
        }

        if (equipB) //Para el panel B
        {
            if (myEquip.equipB == "GUN") //Pistola
            {
                all_Equip[0].SetActive(true);
                canReloadB = true;
                canShootB = true;
                
            }               
            else all_Equip[0].SetActive(false);

            if (myEquip.equipB == "FLASH") //Linterna
            {
                all_Equip[1].SetActive(true);
                medical_UsefullA = false;
                canReloadA = false;
                canShootA = false;
            }              
            else all_Equip[1].SetActive(false);

            if (myEquip.equipB == "KNIFE") //Cuchillo
            {
                all_Equip[2].SetActive(true);
                medical_UsefullA = false;
                canReloadA = false;
                canShootA = false;
            }               
            else all_Equip[2].SetActive(false);

            if (myEquip.equipB == "MEDICAL") //Medicamento Full
            {
                medical_UsefullB = true;
                canReloadA = false;
                canShootA = false;
            }           
            medical_UsefullA = false;
            canReloadA = false;
            canShootA = false;
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

    //Uso de m�dicamento 
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

    //Acci�n de recargar
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
