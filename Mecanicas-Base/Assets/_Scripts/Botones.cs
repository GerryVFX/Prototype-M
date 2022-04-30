using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    public AudioSource button_sounds;
    public AudioClip[] button_Clips;

    private void Start()
    {
        button_sounds = GetComponent<AudioSource>();
    }
    public void SoundPass()
    {
        button_sounds.clip = button_Clips[0];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }
    public void SoundClic()
    {
        button_sounds.clip = button_Clips[1];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }
    public void SoundEnter()
    {
        button_sounds.clip = button_Clips[2];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }

    public void SoundBack()
    {
        button_sounds.clip = button_Clips[3];

        button_sounds.enabled = false;
        button_sounds.enabled = true;
    }


}
