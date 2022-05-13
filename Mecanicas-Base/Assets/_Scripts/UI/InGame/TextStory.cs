using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextStory : MonoBehaviour
{
    //Paneles para almacenar archivos
    public GameObject[] Paneles;

    //Contenedor de texto
    public TMP_Text content_Text;
    public TMP_Text[] text_Story;//Colección de textos para la historia

    //Archivos primera carpeta
    public void TextC1T1() //Archivo 1
    {
        content_Text.text = text_Story[1].text;
    }
    public void TextC1T2() //Archivo 2
    {
        content_Text.text = text_Story[2].text;
    }

    //Para desactivar textos si se cierra el menú
    public void DesactivePanels()
    {
        if (Paneles[0].tag != "ActivePanel")
        {
            GameObject lastActive = GameObject.FindGameObjectWithTag("ActivePanel");
            lastActive.tag = "InactivePanel";
            lastActive.SetActive(false);

            Paneles[0].tag = "ActivePanel";
            Paneles[0].SetActive(true);
            content_Text.text = "";
        }
    }
    public void Panel1() //Para activar el panel de archivos de la primera carpeta
    {
        if (Paneles[1].tag != "ActivePanel")
        {
            GameObject lastActive = GameObject.FindGameObjectWithTag("ActivePanel");
            lastActive.tag = "InactivePanel";
            lastActive.SetActive(false);
            
            Paneles[1].tag = "ActivePanel";
            Paneles[1].SetActive(true);
        }
    }
}
