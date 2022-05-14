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
    public bool zombi_Alert;
    public bool zombi_IsDead;
    public bool is_Hurt;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        player_Speed = FindObjectOfType<MovePlayer>();
        nav = GetComponent<NavMeshAgent>();
        animZombi = GetComponent<Animator>();     
    }

    private void Update()
    {
        //Seguir al player una vez detectado
        if (!zombi_IsDead)
        {
            FollowToPlayer();
        }
        
        //Validación para la muerte del enemigo
        if (life <= 0)
        {
            zombi_IsDead = true;
            StopCoroutine(ZombiReaction());
            zombi_Alert = false;
            StartCoroutine(DeadZombie());
        }
    }

    //Detecciónn  de bala 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            zombi_Alert = true;
            StartCoroutine(ZombiReaction());     
        }
    }

    //Para la detección del player por distancia o reacción a disparo
    void FollowToPlayer()
    {
        float dist;
        dist = Vector3.Distance(player.position, transform.position);

        if (!zombi_IsDead)
        {
            if (dist < 5 || zombi_Alert && !is_Hurt)
            {
                zombi_Alert = true;
                nav.SetDestination(player.position);
                animZombi.SetBool("IsWalking", true);

                if (dist < 1 && zombi_Alert) //Atacar al player si esta en rango
                {
                    nav.SetDestination(transform.position);
                    animZombi.SetBool("IsWalking", false);
                    animZombi.SetBool("Attack", true);
                }
                else if (dist > 2 && zombi_Alert) //Detener ataque y seguir al player si sale de rango
                {
                    nav.SetDestination(player.position);
                    animZombi.SetBool("IsWalking", true);
                    animZombi.SetBool("Attack", false);
                }
            }
        }
        else
        {
            nav.SetDestination(transform.position);
            animZombi.SetBool("IsWalking", false);
            animZombi.SetBool("IsDead", true);
        }
    }

    //Corrutina para la muerte del enemigo
    IEnumerator DeadZombie()
    {
        nav.SetDestination(transform.position);
        animZombi.SetBool("IsDead", true);
        yield return new WaitForSeconds(5f);
        //Destroy(this.gameObject);
    }

    //Reacción de enemigo al disparo
    IEnumerator ZombiReaction()
    {
        is_Hurt = true;
        nav.SetDestination(transform.position);
        animZombi.SetTrigger("Hurt");
        life -= 2;
        yield return new WaitForSeconds(1f);
        if (!zombi_IsDead)
        {
            is_Hurt = false;
            zombi_Alert = true;
            nav.SetDestination(player.position);
        }     
    }
}
