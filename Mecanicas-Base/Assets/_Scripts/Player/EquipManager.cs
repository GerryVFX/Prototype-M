using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EquipManager : MonoBehaviour
{
    //Gestion de equipo
    public bool gun, bullets_gun, flash, knife, shootgun, rifle, axe, hardgun;
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
    public int bulles_reserv;
    public TMP_Text[] bullets;

    //Menú ráido vacio
    private void Start()
    {
        lastequip = "Empty";
        equipA = "Empty";
        equipB = "Empty";
        bullets_length = 0;
    }

    //Gestión de recursos
    
   
    
    //Revisión de imagenes asignadas a menú rápido
    private void Update()
    {
        
        bullets[0].text = "x " + bullets_length.ToString();
        bullets[1].text = "x " + bullets_length.ToString();
        bullets[2].text = "x " + bullets_length.ToString();
        
        EquipManagment();
        ImageEquipAsign();    
    }

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
        bullets_Cases[1].SetActive(false);
    }

    //Relación equipo en menú ráido e imagens de referencia
    void ImageEquipAsign()
    {
        //Para el quipo A
        if (equipA == "Empty") equip1.sprite = equipIMG[0];
        if (equipA == "GUN") equip1.sprite = equipIMG[1];
        if (equipA == "FLASH") equip1.sprite = equipIMG[2];
        if (equipA == "KNIFE") equip1.sprite = equipIMG[3];
        //Para el qeuipo B
        if (equipB == "Empty") equip2.sprite = equipIMG[0];
        if (equipB == "GUN") equip2.sprite = equipIMG[1];
        if (equipB == "FLASH") equip2.sprite = equipIMG[2];
        if (equipB == "KNIFE") equip2.sprite = equipIMG[3];

    }
}
