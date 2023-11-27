using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);

    }

    public void options()
    {
        panel.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();//para terminar el programa, solo cuando es un ejecutable, desde unity no funciona
    }

    public void Creditos()
    {
        panel.SetActive(true);
    }

    public void SalirCreditos()
    {
        panel.SetActive(false);
    }

    public void GoMenu() { SceneManager.LoadScene("Menu"); }

    public void lvl1() { SceneManager.LoadScene("Level1"); }
    public void lvl2() { SceneManager.LoadScene("Level2"); }
    public void lvl3() { SceneManager.LoadScene("Level3"); }
}
