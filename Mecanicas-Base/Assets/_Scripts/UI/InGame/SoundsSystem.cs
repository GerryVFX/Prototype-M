using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsSystem : MonoBehaviour
{
    AudioSource my_Source;
    public AudioClip[] my_Clips; //Colección de sonidos para la escena
    
    void Start()
    {
        my_Source = GetComponent<AudioSource>();
    }

    //Control de sonidos en esta escena
    public void SoundMenu()
    {
        my_Source.clip = my_Clips[0];
        my_Source.Play();
    }

    public void MenuPagePass()
    {
        my_Source.clip = my_Clips[1];
        my_Source.Play();
    }

    public void MenuPanels()
    {
        my_Source.clip = my_Clips[2];
        my_Source.Play();
    }

    public void Heal()
    {
        my_Source.clip = my_Clips[3];
        my_Source.Play();
    }

    public void Reload()
    {
        my_Source.clip = my_Clips[4];
        my_Source.Play();
    }

    public void Shoot()
    {
        my_Source.clip = my_Clips[5];
        my_Source.Play();
    }
}
