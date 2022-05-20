using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextStory : MonoBehaviour
{
    public GameObject[] Paneles;

    public TMP_Text content_Text;
    public TMP_Text[] text_Story;

    GuiControl close_Menu;
    private void Start()
    {
        close_Menu = FindObjectOfType<GuiControl>();
    }

    //private void Update()
    //{
    //    if (close_Menu.inMenu == false)
    //    {
    //        DesactivePanels();
    //    }
    //}
    public void ActivePanelText()
    {
        GameObject activePanel = GameObject.FindGameObjectWithTag("ActivePanel");
        
    }

    public void TextC1T1()
    {
        content_Text.text = text_Story[1].text;
    }
    public void TextC1T2()
    {
        content_Text.text = text_Story[2].text;
    }

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
    public void Panel1()
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
