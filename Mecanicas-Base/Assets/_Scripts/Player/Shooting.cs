using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Variables para interactuar con el enemigo
    GameObject zombiReaction;
    Enemi_01 zombi;


    //Variables para enlazar con el player
    PlayerMain playerAim;
    EquipManager bullets;
    
    void Start()
    {
        zombi = FindObjectOfType<Enemi_01>();
        playerAim = FindObjectOfType<PlayerMain>();
        bullets = GetComponent<EquipManager>();
        zombiReaction = GameObject.FindGameObjectWithTag("Enemy");
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayPosition = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, rayPosition, out hit))
                print("Found an object - distance: " + hit.transform.name);

            if (hit.transform.gameObject.tag=="Enemy")
            {
                StartCoroutine(HitMark());
                zombi.life -= 1;
            }

        }
    }

    IEnumerator HitMark()
    {
        zombiReaction.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        zombiReaction.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
