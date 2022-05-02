using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Slección de control
    public bool control_Modern;
    public bool control_Tank;

    //Para el movimiento en Control Moderno
    private float move_x;
    private float move_z;
    private CharacterController player_controller;
    private Vector3 player_direction;
    private Vector3 movePLayer;

    public Camera micam;
    private Vector3 camFoward;
    private Vector3 camRight;

    //Para el movimiento en Control tanque
    float turnSpeed = 150f;
    bool moving_Foward;
    public bool moving_Backward;
    public bool left_turn;

    //Estados del personaje
    public bool isWalking, isSneakIdle, isSneakWalking, isRunning;
    PlayerMain player_Aim;

    //Variables para velocidad y gravedad
    [SerializeField]
    float player_speed;
    float gravity = 500f;

    //Declaración de variables
    void Start()
    {
        player_controller = GetComponent<CharacterController>();
        player_Aim = GetComponent<PlayerMain>();
    }

    //Detectar estados del jugador
    private void FixedUpdate()
    {
        if (!player_Aim.isAim)
        {
            Moving();
        }
        else Aim();
        
        StatesPlayer();
    }

    //Movimiento según tipo de control
    void Moving()
    {
        //Selector de control
        if (control_Modern)
        {
            MoveWhitModern();
        }

        if (control_Tank)
        {
            MoveWhitTank();
        }
    }

    //Giro apuntado 
    private void Aim()
    {
        move_x = Input.GetAxisRaw("Horizontal");
        float h = move_x * Time.deltaTime * turnSpeed;
        Vector3 turn = new Vector3(0, h, 0);
        transform.Rotate(turn);
    } 

    //Movimiento para el control moderno
    private void MoveWhitModern()
    {
        move_x = Input.GetAxis("Horizontal");
        move_z = Input.GetAxis("Vertical");

        player_direction = new Vector3(move_x, 0, move_z);
        player_direction = Vector3.ClampMagnitude(player_direction, 1);

        CamDirection();
        
        movePLayer = player_direction.x * camRight + player_direction.z * camFoward;
        movePLayer = movePLayer * player_speed;        
        player_controller.transform.LookAt(player_controller.transform.position + movePLayer);

        movePLayer.y = -gravity * Time.deltaTime;

        player_controller.Move(movePLayer * Time.deltaTime);
    }
     //Movimiento relativo a la cámara   
    void CamDirection()
    {
        camFoward = micam.transform.forward;
        camRight = micam.transform.right;

        camFoward.y = 0;
        camRight.y = 0;

        camFoward = camFoward.normalized;
        camRight = camRight.normalized;
    }

    //Control de Tanque
    private void MoveWhitTank()
    {
        //Detección del valor para el input para el movimiento
        if (move_x > 0)
        {
            move_x = 1;
        }
        else if (move_x < 0)
        {
            move_x = -1;
        }
        else move_x = 0;

        if (move_z > 0)
        {
            move_z = 1;
        }
        else if (move_z < 0)
        {
            move_z = -1;
        }
        else move_x = 0;

        move_x = Input.GetAxisRaw("Horizontal");
        move_z = Input.GetAxisRaw("Vertical");

        //Variables nomralizadas con respecto al tiempo y velocidad de giro y avance
        float h = move_x * Time.deltaTime * turnSpeed;
        float v = move_z * Time.deltaTime * player_speed;

        moving_Foward = false;
        moving_Backward = false;

        //Movimientos
        if (move_z > 0)
        {
            if (!moving_Foward)
            {
                moving_Foward = true;
            }
        }
        else if (move_z < 0)
        {           
            moving_Foward = false;
            moving_Backward = true;
        }
        else
        {
            moving_Foward = true;
        }

        if (move_x < 0 || move_x > 0)
        {
            left_turn = true;
        }
        else left_turn = false;

        Vector3 move = new Vector3(0, 0, v);
        move = transform.TransformDirection(move);
        move.y -= gravity * Time.deltaTime;
        player_controller.Move(move);

        Vector3 turn = new Vector3(0, h, 0);
        transform.Rotate(turn);
    }

    void StatesPlayer()
    {
        //Estado de caminado moderno
        if (move_x > 0 || move_x < 0 || move_z > 0 || move_z < 0)
        {
            player_speed = 2.5f;
            isWalking = true;
        }
        else isWalking = false;

        if (moving_Backward)
        {
            player_speed = 1;
        }
        else player_speed = 2.5f;

        //Estado de agacharse 
        if (Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Space))
        {
            player_speed = 1f;
            isRunning = false;
            isSneakIdle = true;
        }
        else isSneakIdle = false;

        //Estado de correr
        if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.LeftShift) && !isSneakIdle)
        {
            player_speed = 5f;
            isRunning = true;
        }
        else isRunning = false;
    }
}
