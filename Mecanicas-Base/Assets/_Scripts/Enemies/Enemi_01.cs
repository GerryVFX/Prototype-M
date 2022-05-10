using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemi_01 : MonoBehaviour
{
    public int life = 8;

    [SerializeField]
    Transform player;
    MovePlayer player_Speed;
    Shooting ray;
    
    NavMeshAgent nav;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        ray = FindObjectOfType<Shooting>();
        player_Speed = FindObjectOfType<MovePlayer>();
        nav = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        

        if (life <= 0)
        {
            nav.SetDestination(transform.position);
            GetComponent<MeshRenderer>().material.color = Color.black;
            Destroy(this.gameObject, 2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (other.CompareTag("Player") && player_Speed.player_speed > 1)
            {
                float dist = Vector3.Distance(player.position, transform.position);
                if (dist > 1)
                {
                    transform.LookAt(player);
                    nav.SetDestination(player.position);
                }
                else nav.SetDestination(transform.position);
            }
            
        }
    }

   

   
}
