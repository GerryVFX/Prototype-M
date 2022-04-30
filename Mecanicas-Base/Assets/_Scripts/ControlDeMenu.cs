using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlDeMenu : MonoBehaviour
{
    //Referencias de Canvas
    public GameObject pantalla_Titulo;
    public GameObject menu_Titulo;
    public GameObject menu_opciones;

    //Imagenes para fundido
    public Image Fades;

    //Verificar si se esta en ociones
    bool inOptions;

    //Primer fundido
    public void Start()
    {
        StartCoroutine(FirstTime());
    }

    //Revisar para regresar a la pantalla anterior
    void Update()
    {
        Regresar();
    }

    //Funciones para botones y cambio de canvas
    public void EntrarMenu()
    {
        StartCoroutine(paseAmenu());
    }

    public void EntrarOpciones()
    {
        StartCoroutine(paseAoption());
        inOptions = true;
    }

    public void GoTest()
    {
        StartCoroutine(GotoTest());
    }
        
    //Función para regresar a la pantalla anterior
    public void Regresar()
    {
        if (inOptions)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Backspace))
            {
                StartCoroutine(BackToMenu());
                inOptions = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Backspace))
        {
            StartCoroutine(BackToTitle());
        }
    }

    //Coroutinas para el fundido de cambio de menu.
    IEnumerator FirstTime()
    {
        Fades.CrossFadeAlpha(0, 3, false);
        yield return new WaitForSeconds(3);
        Fades.enabled = false;
    }

    IEnumerator paseAmenu()
    {
        Fades.enabled = true;
        Fades.CrossFadeAlpha(1, 2f, false);
        pantalla_Titulo.SetActive(false);
        yield return new WaitForSeconds(2f);
        menu_Titulo.SetActive(true);
        Fades.CrossFadeAlpha(0, 2f, false);
        yield return new WaitForSeconds(2f);
        Fades.enabled = false;
    }

    IEnumerator paseAoption()
    {
        Fades.enabled = true;
        Fades.CrossFadeAlpha(1, 2f, false);
        menu_Titulo.SetActive(false);
        yield return new WaitForSeconds(2f);
        menu_opciones.SetActive(true);
        Fades.CrossFadeAlpha(0, 2f, false);
        yield return new WaitForSeconds(2f);
        Fades.enabled = false;
    }

    IEnumerator BackToMenu()
    {
        Fades.enabled = true;
        Fades.CrossFadeAlpha(1, 2f, false);
        menu_opciones.SetActive(false);
        yield return new WaitForSeconds(2f);
        menu_Titulo.SetActive(true);
        Fades.CrossFadeAlpha(0, 2f, false);
        yield return new WaitForSeconds(2f);
        Fades.enabled = false;
    }

    IEnumerator BackToTitle()
    {
        Fades.enabled = true;
        Fades.CrossFadeAlpha(1, 2f, false);
        menu_Titulo.SetActive(false);
        yield return new WaitForSeconds(2f);
        pantalla_Titulo.SetActive(true);
        Fades.CrossFadeAlpha(0, 2f, false);
        yield return new WaitForSeconds(2f);
        Fades.enabled = false;
    }

    IEnumerator GotoTest()
    {
        Fades.enabled = true;
        Fades.CrossFadeAlpha(1, 2f, false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
