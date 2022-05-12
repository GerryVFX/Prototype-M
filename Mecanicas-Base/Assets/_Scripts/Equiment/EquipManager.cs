using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EquipManager : MonoBehaviour
{
    //Gestion de equipo
    //Validación de obtención de armas;
    public bool gun, flash, knife, shootgun, rifle, axe, hardgun, bullets_gun, medical;

    //Imagenes para el menú de equipo
    public GameObject[] wepons_Panels;

    //Para asignar a menú rápido
    public string equipA;
    public string equipB;
    public string lastequip;

    //Para realizar el cambio de imagenes en el menú rápido
    public Image equip1;
    public Image equip2;
    public Sprite[] equipIMG;

    //Control de balas y su visualización en menú rápido
    public GameObject[] bullets_Cases;
    public int bullets_length;
    public int bullets_reserv;
    public TMP_Text[] bullets;
    public TMP_Text bullets_reservText;

    //Conrtrol para que el jugador pueda recargar balas
    PlayerMain equi_player;

    //Control de equipos médicos para restaurar salud;
    public int medical_reserv = 0;
    public TMP_Text medical_Cases;

    //---------------------------------------------------------
    //Menú ráido vacio
    private void Start()
    {
        equi_player = FindObjectOfType<PlayerMain>();
        lastequip = "Empty";
        equipA = "Empty";
        equipB = "Empty";
        bullets_length = 4;
    }

    //Revisión de imagenes asignadas a menú rápido
    private void Update()
    {
        //Actualización de número de balas en reserva y en el cargador
        bullets[0].text = "x " + bullets_length.ToString();
        bullets[1].text = "x " + bullets_length.ToString();
        bullets[2].text = "x " + bullets_length.ToString();
        bullets_reservText.text = "x " + bullets_reserv.ToString();

        //Actualización de número de equipos médicos en reserva
        medical_Cases.text = "x " + medical_reserv.ToString();

        //Activación de armas en el menú de equipo
        EquipManagment();

        //Actualización de mimágenes en el menú rápido
        ImageEquipAsign();    
    }

    //Activación de armas en el menú de equipo
    public void EquipManagment()
    {
        if (knife)
        {
            wepons_Panels[0].SetActive(true);
        }
        else wepons_Panels[0].SetActive(false);
    }
    
    //Asignación de equipo a menú ráido
    //Para pistola
    public void EquipGuninA()
    {
        if (equipB == "GUN")
        {
            //Para evitar ducplicidad
            lastequip = equipA;
            equipB = lastequip;
            bullets_Cases[1].SetActive(false);
        }
        equipA = "GUN";
        bullets_Cases[0].SetActive(true); 
    }
    public void EquipGuninB()
    {
        if (equipA == "GUN")
        {
            lastequip = equipB;
            equipA = lastequip;
            bullets_Cases[0].SetActive(false);
        }
        equipB = "GUN";
        bullets_Cases[1].SetActive(true);    
    }

    //Para linterna
    public void EquipFlashinA()
    {
        if (equipB == "FLASH")
        {
            lastequip = equipA;
            equipB = lastequip;
            if (lastequip == "GUN") bullets_Cases[1].SetActive(true);
        }
        equipA = "FLASH";
        equi_player.canReloadA = false;
        bullets_Cases[0].SetActive(false);
    }
    public void EquipFlashinB()
    {
        if (equipA == "FLASH")
        {
            lastequip = equipB;
            equipA = lastequip;
            if (lastequip == "GUN") bullets_Cases[0].SetActive(true);
        }
        equipB = "FLASH";
        equi_player.canReloadB = false;
        bullets_Cases[1].SetActive(false);
    }

    //Para cuchillo
    public void EquipKnifeinA()
    {
        if (equipB == "KNIFE")
        {
            lastequip = equipA;
            equipB = lastequip;
            if (lastequip == "GUN") bullets_Cases[1].SetActive(true);
        }
        equipA = "KNIFE";
        equi_player.canReloadA = false;
        bullets_Cases[0].SetActive(false);
    }
    public void EquipKnifeinB()
    {
        if (equipA == "KNIFE")
        {
            lastequip = equipB;
            equipA = lastequip;
            if (lastequip == "GUN") bullets_Cases[0].SetActive(true);
            
        }
        equipB = "KNIFE";
        equi_player.canReloadB = false;
        bullets_Cases[1].SetActive(false);
    }

    //Para medicamento Full
    public void EquipMedicalA()
    {
        if (medical_reserv > 0)
        {
            if (equipB == "MEDICAL" && medical_reserv > 0)
            {
                lastequip = equipA;
                equipB = lastequip;
                if (lastequip == "GUN") bullets_Cases[1].SetActive(true);
            }
            equipA = "MEDICAL";
            equi_player.canReloadA = false;
            bullets_Cases[0].SetActive(false);
        }
        else if (equipA == "MEDICAL" && medical_reserv <= 0) equipA = "Empty";

    }
    public void EquipMedicalB()
    {
        if (medical_reserv > 0)
        {
            if (equipA == "MEDICAL" && medical_reserv > 0)
            {
                lastequip = equipB;
                equipA = lastequip;
                if (lastequip == "GUN") bullets_Cases[0].SetActive(true);
            }
            equipB = "MEDICAL";
            equi_player.canReloadB = false;
            bullets_Cases[1].SetActive(false);
        }
        else if (equipB == "MEDICAL" && medical_reserv <= 0) equipB = "Empty";
    }

    //Relación equipo en menú ráido e imagens de referencia
    void ImageEquipAsign()
    {
        //Para el quipo A
        if (equipA == "Empty") equip1.sprite = equipIMG[0];
        if (equipA == "GUN") equip1.sprite = equipIMG[1];
        if (equipA == "FLASH") equip1.sprite = equipIMG[2];
        if (equipA == "KNIFE") equip1.sprite = equipIMG[3];
        if (equipA == "MEDICAL") equip1.sprite = equipIMG[4];
        //Para el qeuipo B
        if (equipB == "Empty") equip2.sprite = equipIMG[0];
        if (equipB == "GUN") equip2.sprite = equipIMG[1];
        if (equipB == "FLASH") equip2.sprite = equipIMG[2];
        if (equipB == "KNIFE") equip2.sprite = equipIMG[3];
        if (equipB == "MEDICAL") equip2.sprite = equipIMG[4];

    }
}
