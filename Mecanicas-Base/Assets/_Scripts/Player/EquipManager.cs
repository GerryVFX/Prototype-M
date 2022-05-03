using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipManager : MonoBehaviour
{
    //Para casignar a menú rápido
    public string equipA;
    public string equipB;
    public string lastequip;

    //Para realizar el cambio de imagenes en el menú rápido
    public Image equip1;
    public Image equip2;

    public Sprite[] equipIMG;

    //Control de balas y su visualización en menú rápido
    public GameObject[] bullets;

    //Menú ráido vacio
    private void Start()
    {
        lastequip = "Empty";
        equipA = "Empty";
        equipB = "Empty";
    }

    //Revisión de imagenes asignadas a menú rápido
    private void Update()
    {
        ImageEquipAsign();
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
            bullets[1].SetActive(false);
        }
        equipA = "GUN";
        bullets[0].SetActive(true); 
    }
    public void EquipGuninB()
    {
        if (equipA == "GUN")
        {
            lastequip = equipB;
            equipA = lastequip;
            bullets[0].SetActive(false);
        }
        equipB = "GUN";
        bullets[1].SetActive(true);    
    }

    //Para linterna
    public void EquipFlashinA()
    {
        if (equipB == "FLASH")
        {
            lastequip = equipA;
            equipB = lastequip;
            if (lastequip == "GUN") bullets[1].SetActive(true);
        }
        equipA = "FLASH";
        bullets[0].SetActive(false);
    }
    public void EquipFlashinB()
    {
        if (equipA == "FLASH")
        {
            lastequip = equipB;
            equipA = lastequip;
            if (lastequip == "GUN") bullets[0].SetActive(true);
        }
        equipB = "FLASH";
        bullets[1].SetActive(false);
    }

    //Para cuchillo
    public void EquipKnifeinA()
    {
        if (equipB == "KNIFE")
        {
            lastequip = equipA;
            equipB = lastequip;
            if (lastequip == "GUN") bullets[1].SetActive(true);
        }
        equipA = "KNIFE";
        bullets[0].SetActive(false);
    }
    public void EquipKnifeinB()
    {
        if (equipA == "KNIFE")
        {
            lastequip = equipB;
            equipA = lastequip;
            if (lastequip == "GUN") bullets[0].SetActive(true);
            
        }
        equipB = "KNIFE";
        bullets[1].SetActive(false);
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
