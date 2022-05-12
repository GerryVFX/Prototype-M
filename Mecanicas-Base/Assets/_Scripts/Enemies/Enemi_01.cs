using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemi_01 : MonoBehaviour
{
    //Variable para la vida del enemigo
    public int life = 8;

    //Variables para interactuar con el player
    [SerializeField]
    Transform player;
    MovePlayer player_Speed;
    
    //Animacionaes y navegación de AI
    public Animator animZombi;
    NavMeshAgent nav;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        player_Speed = FindObjectOfType<MovePlayer>();
        nav = GetComponent<NavMeshAgent>();
        animZombi = GetComponent<Animator>();     
    }

    private void Update()
    {
        //Validación para la muerte del enemigo
        if (life <= 0)
        {
            StartCoroutine(DeadZombie());
        }
    }

    //Detección del player y acción para seguirlo y atacar
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.CompareTag("Player"))
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

    //Cancelar ataque en caso de que salgo de rango
    private void OnTriggerExit(Collider other)
    {
        animZombi.SetBool("Attack", false);
    }

    //Corrutina para la muerte del enemigo
    IEnumerator DeadZombie()
    {
        nav.SetDestination(transform.position);
        animZombi.SetBool("IsDead", true);
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
