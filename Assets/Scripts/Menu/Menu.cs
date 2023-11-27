using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel, panel2;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        panel2.SetActive(false);
    }

    public void Jugar()
    {
        panel2.SetActive(true);
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

    public void SalirPanel()
    {
        panel2.SetActive(false);
    }

    public void lvl1() { SceneManager.LoadScene("Level1");}
    public void lvl2() { SceneManager.LoadScene("Level2"); }
    public void lvl3() { SceneManager.LoadScene("Level3"); }
}
