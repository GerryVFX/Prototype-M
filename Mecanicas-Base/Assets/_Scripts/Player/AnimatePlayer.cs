using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    //Estados generales y de estatus del jugador
    [SerializeField]
    PlayerMain mainPlayer;

    //Estados de movimiento del jugador
    MovePlayer player_States;

    //Variable para el control de animaciones
    public Animator animPlayer;

    //Declaración de variables
    void Start()
    {
        mainPlayer = FindObjectOfType<PlayerMain>();
        player_States = FindObjectOfType<MovePlayer>();
        animPlayer = GetComponent<Animator>();
    }

    //Activación de animaciones
    private void FixedUpdate()
    {
        Animations();
    }

    //Gestión de animaciones según estados
    void Animations()
    {
        //Para caminar
        if (player_States.isWalking)
        {
            animPlayer.SetBool("IsWalk", true);
        }
        else animPlayer.SetBool("IsWalk", false);

        //Para caminar hacia atras
        if (player_States.moving_Backward)
        {
            animPlayer.SetBool("IsWalkBack", true);
        }
        else animPlayer.SetBool("IsWalkBack", false);

        //Para caminar de lado
        if (player_States.left_turn)
        {
            animPlayer.SetBool("WalkLeft", true);
        }
        else animPlayer.SetBool("WalkLeft", false);

        //Para agacharse
        if (player_States.isSneakIdle)
        {
            animPlayer.SetBool("IsSneak", true);
        }
        else animPlayer.SetBool("IsSneak", false);

        //Para correr
        if (player_States.isRunning && !player_States.isSneakIdle)
        {
            animPlayer.SetBool("IsRunning", true);
        }
        else animPlayer.SetBool("IsRunning", false);

        //Para apuntar
        if (mainPlayer.isAim)
        {
            animPlayer.SetBool("IsAim", true);
        }
        else animPlayer.SetBool("IsAim", false);
       
    }
}
