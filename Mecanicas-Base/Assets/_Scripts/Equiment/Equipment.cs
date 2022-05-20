using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField]
    EquipManager equipActive;
    public GameObject[] messages;

    private void Start()
    {
        equipActive = FindObjectOfType<EquipManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        messages[0].SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            if (Input.GetKey(KeyCode.G))
            {
                messages[0].SetActive(false);

                if (this.gameObject.tag == "knife")
                {
                    StartCoroutine(TakeEquipKnife());
                }
                else if (this.gameObject.tag == "medical")
                {
                    equipActive.medical = true;
                    equipActive.medical_reserv += 1;
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "Bullets")
                {
                    equipActive.bullets_gun = true;
                    equipActive.bullets_reserv += 15;
                    Destroy(this.gameObject);
                }
                
            }
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            messages[0].SetActive(false);
        }
    }

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
