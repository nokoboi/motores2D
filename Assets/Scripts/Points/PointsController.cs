using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public int points;
    public bool entry;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        entry = false;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !entry)
        {
            entry=true;

            sound.Play();

            collision.gameObject.GetComponent<PlayerController>().IncrementPoints(points);

            Destroy(gameObject,0.3f);
        }
    }
}
