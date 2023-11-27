using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;


    public void SetVidasTxt(int vidas)
    {
        vidasTxt.text = "HP: " + vidas;
    }
}
