using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    //Variable para validad con el equipo en menús
    EquipManager equipActive;

    //Mensajes para objetos
    public GameObject[] messages;


    private void Start()
    {
        equipActive = FindObjectOfType<EquipManager>();
    }

    //Activación de mensajes para tomar equipo
    private void OnTriggerEnter(Collider other)
    {
        messages[0].SetActive(true);
    }

    //Obtención de equipos 
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.G))
            {
                messages[0].SetActive(false);

                if (this.gameObject.tag == "knife") //Para chuchillo
                {
                    StartCoroutine(TakeEquipKnife());
                }
                else if (this.gameObject.tag == "medical") //Para médicamento Full
                {
                    equipActive.medical = true;
                    equipActive.medical_reserv += 1;
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "Bullets") //Para balas
                {
                    equipActive.bullets_gun = true;
                    equipActive.bullets_reserv += 15;
                    Destroy(this.gameObject);
                }
            }
        }      
    }

    //Desactiva el mensaje indicativo para tomar objetos
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            messages[0].SetActive(false);
        }
    }

    //Corrutina para activar mensaje narrativo y obtener cuchillo
   IEnumerator TakeEquipKnife()
    {
        messages[1].SetActive(true);
        equipActive.knife = true;
        GetComponent<AudioSource>().Play();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(5);
        messages[1].SetActive(false);
        Destroy(this.gameObject);
    }
}
