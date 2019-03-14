using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;
    private bool grounded;
    private bool jumping, movendo;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //Melhor colocar o move aqui pra ele ser usado por todos os métodos
    float move;

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (move != 0f)
        {
            Mover();
            Flip();
        }

        // Função do pulo chamada em todos os Frames
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumping = true;
        }
    }

    void FixedUpdate()
    {
        // Movimento
        if (movendo)
        {
            Mover();
        }
        // Pulo
        if (jumping)
        {
            Pular();
        }

    }

    void Flip()
    {
        if (move > 0)
        {
            sprite.flipX = false;
        } else {
            sprite.flipX = true;
        }
    }

    // Funções de físicas usadas no fixed update
    void Pular()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        jumping = false;
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }

    void Mover()
    {
        rb.transform.Translate(new Vector2(move * maxSpeed * Time.fixedDeltaTime, rb.velocity.y));
    }
}