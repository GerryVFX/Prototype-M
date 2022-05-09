using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Button_Sounds : MonoBehaviour
{
    //Variables AudiosSource y Array de clips
    public AudioSource button_sounds;
    public AudioClip[] button_Clips;

    //Busca componenete de AudioSource
    private void Start()
    {
        button_sounds = GetComponent<AudioSource>();
    }

    //Gestión de sonidos para el Event de los botones

    //Sonido cuando se pase por arriba del  boton
    public void SoundPass()
    {
        button_sounds.clip = button_Clips[0];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }

    //Sonido para cuando se pase de escena entre menús
    public void SoundClic()
    {
        button_sounds.clip = button_Clips[1];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }

    //Sonido para cuando se entra al juego
    public void SoundEnter()
    {
        button_sounds.clip = button_Clips[2];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }

    //SOnido para cuando se regresa a la pantalla anterior
    public void SoundBack()
    {
        button_sounds.clip = button_Clips[3];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }
}
