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

    public Animator animZombi;
    NavMeshAgent nav;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        ray = FindObjectOfType<Shooting>();
        player_Speed = FindObjectOfType<MovePlayer>();
        nav = GetComponent<NavMeshAgent>();
        animZombi = GetComponent<Animator>();
        
    }

    private void Update()
    {
        

        if (life <= 0)
        {
            nav.SetDestination(transform.position);
            animZombi.SetBool("IsDead", true);
            
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
                    animZombi.SetBool("IsWalking", true);
                    animZombi.SetBool("Attak", false);
                    nav.SetDestination(player.position);

                }
                else
                {
                    nav.SetDestination(transform.position);
                    animZombi.SetBool("IsWalking", false);
                    animZombi.SetBool("Attack", true);
                }


            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        animZombi.SetBool("Attack", false);
    }




}
