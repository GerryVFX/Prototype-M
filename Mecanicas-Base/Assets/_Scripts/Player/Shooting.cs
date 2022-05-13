using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Variables para interactuar con el enemigo
    GameObject zombiReaction;
    public int zombilife=8;
    
    //Variables para enlazar con el player
    PlayerMain playerAim;
    EquipManager bullets;
    AnimatePlayer animShoot;

    //Control de sonidos
    SoundsSystem shoot_Sounds;

    //Para efecto del disparo
    public GameObject fire_Shoot;
    public Transform fire_Spawn;
    
    void Start()
    {
        playerAim = FindObjectOfType<PlayerMain>();
        bullets = FindObjectOfType<EquipManager>();
        animShoot = FindObjectOfType<AnimatePlayer>();
        shoot_Sounds = FindObjectOfType<SoundsSystem>();
        zombiReaction = GameObject.FindGameObjectWithTag("Enemy");    
    }

    void Update()
    {
        //Disparo por medio de rayCast
        if (fire_Shoot != null)
        {
            fire_Shoot.transform.position = fire_Spawn.position;
        }

        if(playerAim.isAim && bullets.bullets_length > 0)
            if (playerAim.canShootA||playerAim.canShootB)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    bullets.bullets_length -= 1;
                    animShoot.animPlayer.SetTrigger("IsShoot");
                    shoot_Sounds.Shoot();
                    Instantiate(fire_Shoot);

                    RaycastHit hit;

                    if(Physics.Raycast(transform.position, Vector3.forward, out hit, 10f))
                    {

                        Enemi_01 zombi = hit.transform.GetComponent<Enemi_01>();
                        if (zombi != null)
                        {
                            zombi.life -= 2;
                            zombi.animZombi.SetTrigger("Hurt");
                        }
                    }
                }
            }
    }
 
}
