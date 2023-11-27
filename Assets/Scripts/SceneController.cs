using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        Debug.Log(collision.gameObject.tag.ToString());

        if(collision.gameObject.CompareTag("Player") && player.playerPoints==13)
        {
            Debug.Log("entra");

            StartCoroutine(Level2(collision));            
        }
        else if (collision.gameObject.CompareTag("Player") && player.playerPoints == 11)
        {
            Debug.Log("entra");

            StartCoroutine(Level3(collision));
        }
        else if (collision.gameObject.CompareTag("Player") && player.playerPoints == 12)
        {
            Debug.Log("entra");

            StartCoroutine(Menu(collision));
        }
    }

    IEnumerator Level2(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().GoLevel2();
        yield return new WaitForSeconds(1f);        
    }

    IEnumerator Level3(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().GoLevel3();
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Menu(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().Finish();
        yield return new WaitForSeconds(1f);
    }
}
