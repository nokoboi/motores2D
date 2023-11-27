using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Vector3 initPos, endingPos;
    private bool movingEnd;
    private SpriteRenderer spriteRenderer;
    public int endX, endY;

    private PlayerController playerController;

    public Animator animator;

    private Hud hud;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        endingPos = new Vector3(initPos.x + endX, initPos.y + endY, initPos.z);
        movingEnd = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;

        playerController = FindAnyObjectByType<PlayerController>();
        animator = GetComponent<Animator>();
        canvas = GameObject.Find("CanvasHud").GetComponent<Canvas>();
        hud = canvas.GetComponent<Hud>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (collision.gameObject.CompareTag("Player") && player.vulnerable)
        {
           player.vulnerable = false;

            if(player.life-- <= 1)
            {
                StartCoroutine(EndGame(collision));
            }
            else
            {
                StartCoroutine(LoseLife(collision));
            }
        }

        if (collision.gameObject.tag == "Player" && gameObject.tag == "vacio")
        {
            StartCoroutine(EndGame(collision));
        }

        hud.SetVidasTxt(collision.gameObject.GetComponent<PlayerController>().life);
    }

    IEnumerator LoseLife(Collision2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(3f);
        collision.gameObject.GetComponent<PlayerController>().vulnerable = true;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator EndGame(Collision2D collision)
    {
        Camera.main.transform.parent = null;
        //collision.gameObject.GetComponent<Transform>().Rotate(new Vector3(0,0,90));
        collision.gameObject.GetComponent<PlayerController>().dead = true;

        collision.gameObject.GetComponent<SpriteRenderer>().color= Color.red;
        
        yield return new WaitForSeconds(0.3f);
        collision.gameObject.GetComponent<PlayerController>().Lose();
    }

    // Update is called once per frame
    void Update()
    {
        MovingEnemy();
    }

    private void MovingEnemy()
    {
        Vector3 destiny = (movingEnd) ? endingPos : initPos;        

        transform.position = Vector3.MoveTowards(transform.position, destiny, speed * Time.deltaTime);

        if(transform.position == endingPos)
        {
            movingEnd = false;
            spriteRenderer.flipX = false;
                        
        }
        else if(transform.position == initPos) 
        {
            movingEnd = true;

            spriteRenderer.flipX = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.hit = true;
            animator.Play("eagleDeath");

            Destroy(gameObject,0.4f);
        }
    }
}
