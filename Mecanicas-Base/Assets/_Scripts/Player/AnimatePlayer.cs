using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    [SerializeField]
    PlayerMain mainPlayer;
    MovePlayer player_States;
    Animator animPlayer;

    
    void Start()
    {
        //GameObject.Find("Player").GetComponent<MovePlayer>();
        mainPlayer = FindObjectOfType<PlayerMain>();
        player_States = FindObjectOfType<MovePlayer>();
        animPlayer = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Animations();
    }

    void Animations()
    {
        if (player_States.isWalking)
        {
            animPlayer.SetBool("IsWalk", true);
        }
        else animPlayer.SetBool("IsWalk", false);

        if (player_States.isSneakIdle)
        {
            animPlayer.SetBool("IsSneak", true);
        }
        else animPlayer.SetBool("IsSneak", false);

        if (player_States.isRunning && !player_States.isSneakIdle)
        {
            animPlayer.SetBool("IsRunning", true);
        }
        else animPlayer.SetBool("IsRunning", false);
        if (mainPlayer.isAim)
        {
            animPlayer.SetBool("IsAim", true);
        }
        else animPlayer.SetBool("IsAim", false);
        if (mainPlayer.isAim)
        {
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                animPlayer.SetTrigger("IsShoot");
            }
        }
    }
}
