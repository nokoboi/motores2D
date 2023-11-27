using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D physic;

    float enterX;
    public int jumpForce;
    private SpriteRenderer spriteRenderer;
    public bool dead;
    public int life;
    public bool vulnerable;
    public bool hit = false;

    //puntos del jugador
    public int playerPoints;

    //animations
    public Animator animator;

    public AudioSource sound;

    public Canvas canvas;
    public Hud hud;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        jumpForce = 7;
        physic = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        life = 3;
        vulnerable = true;
        animator = GetComponent<Animator>();

        sound = GetComponent<AudioSource>();


        hud = canvas.GetComponent<Hud>();
        hud.SetVidasTxt(life);

    }

    // Update is called once per frame
    void Update()
    {
        enterX = Input.GetAxis("Horizontal");
        Jump();
        Flip();
        AnimatePlayer();

        if(hit)
        {
            physic.velocity = new Vector3(physic.velocity.x, +jumpForce,0);
            hit = false;
        }

    }

    private void FixedUpdate()
    {
        physic.velocity = new Vector3(enterX * speed, physic.velocity.y, 0);
    }

    private void Jump()
    {
        if(dead) return;

        if(Input.GetKeyDown(KeyCode.Space) && TouchingGround())
        {
            sound.Play();

            physic.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Flip()
    {
        if (physic.velocity.x > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (physic.velocity.x < 0f)
        {
            spriteRenderer.flipX = true;
        }
    }

    public bool TouchingGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -2f,0), Vector2.down, 0.2f);

        return hit.collider != null;
    }

    private void AnimatePlayer()
    {
        if(dead)
        {
            animator.Play("idle");
            return;
        }

        if(!TouchingGround())
        {
            animator.Play("jump");
        }
        else
        {
            if(physic.velocity.x > 1 || physic.velocity.x < -1 && physic.velocity.y == 0)
            {
                animator.Play("run");
            }
            else
            {
                animator.Play("idle");
            }
        }

    }

    public void IncrementPoints(int points)
    {
        playerPoints += points;
    }

    public void Lose()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoLevel2()
    {
        Debug.Log("hola");
        SceneManager.LoadScene("Level2");
    }

    public void GoLevel3()
    {
        Debug.Log("hola");
        SceneManager.LoadScene("Level3");
    }

    public void Finish()
    {
        SceneManager.LoadScene("Menu");
    }
}
