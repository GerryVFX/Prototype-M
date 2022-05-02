using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiControl : MonoBehaviour
{
    //Variables del menú de status
    public GameObject status;
    public GameObject selectA;
    public GameObject selectB;
    [SerializeField]
    public Image equip_1;
    public Image equip_2;
    public Sprite[] all_equip;


    public bool equipA;
    public bool equipB;

    EquipManager n_equip_select;
    

    void Start()
    {
        n_equip_select = FindObjectOfType<EquipManager>();
    }

    //Activa menú de status y cambia equipo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            StartCoroutine(ActiveStatus());
        }

        
        equip_1.sprite = all_equip[n_equip_select.n_equip];
        equip_2.sprite = all_equip[n_equip_select.n_equip2];
    }

    //Activación del menu de status por tiempo y cambia equipo
    IEnumerator ActiveStatus()
    {
        SwitchEquip();
        status.SetActive(true);
        yield return new WaitForSeconds(2);
        status.SetActive(false);
    }

    public void EquipAsignGunA()
    {
        if (n_equip_select.equipment[0].tag != "EquipA")
        {
            GameObject lastEquipA = GameObject.FindGameObjectWithTag("EquipA");
            lastEquipA.tag = "EquipB";
            n_equip_select.equipment[0].tag = "EquipA";
        }
        
        
    }
    public void EquipAsignGunB()
    {
        if (n_equip_select.equipment[0].tag != "EquipB")
        {
            GameObject lastEquipB = GameObject.FindGameObjectWithTag("EquipB");
            lastEquipB.tag = "EquipA";
            n_equip_select.equipment[0].tag = "EquipB";
        }
        

    }

    public void EquipAsignFlashA()
    {
        if (n_equip_select.equipment[1].tag != "EquipA")
        {
            GameObject lastEquipA = GameObject.FindGameObjectWithTag("EquipA");
            lastEquipA.tag = "EquipB";
            n_equip_select.equipment[1].tag = "EquipA";
        }
        

    }
    public void EquipAsignFlashB()
    {
        if (n_equip_select.equipment[1].tag != "EquipB")
        {
            GameObject lastEquipB = GameObject.FindGameObjectWithTag("EquipB");
            lastEquipB.tag = "EquipA";
            n_equip_select.equipment[1].tag = "EquipB";
        }
        

    }

    //Metodo para cambiar equipo
    void SwitchEquip()
    {
        if (equipA)
        {
            equipB = true;
            selectA.SetActive(false);
            equipA = false;
            selectB.SetActive(true);
        }
        else if (equipB)
        {
            equipA = true;
            selectB.SetActive(false);
            equipB = false;
            selectA.SetActive(true);
        }
    }

    
}
