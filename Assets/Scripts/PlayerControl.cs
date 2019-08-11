using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerControl : MonoBehaviour {

    public float jumpForce;
    private bool grounded;
    private bool isJumping;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float tempo;
    private int segundos;
    public float moveVelocity;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator> ();
    }   

    void Update ()
    {
        //Pulo
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            isJumping = true;
        }

        //Movimentação
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveVelocity;

        //Animação Movimentacao
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            this.gameObject.GetComponent<Animator>().SetBool("movendo", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            this.gameObject.GetComponent<Animator>().SetBool("movendo", false);
        }

        //Flipping de Sprites
        Flip();
    }

    void OnCollisionStay2D(Collision2D c)
    {
        grounded = c.collider.CompareTag("Ground");
        
    }
    void OnCollisionExit2D(Collision2D c)
    {
        grounded = false;
    }

    public void HitEnd()
    {
        this.gameObject.GetComponent<Animator>().SetBool("hit", false);
    }

    void FixedUpdate ()
    {
        anim.SetFloat("velY", rb.velocity.y);
        
        if (isJumping) 
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    void Flip ()
    {
        sprite.flipX = Input.GetAxis("Horizontal") < 0 ? true : false;
    }
    
    public void AumentarVelocidadeTemp(int v, int t)
    {
        StartCoroutine(BoostVelocityCoroutine(v, t));
    }
    IEnumerator BoostVelocityCoroutine(int v, int t)
    {
        bool cond = true;
        while (cond)
        {
            var vn = this.moveVelocity;
            Debug.Log("Esperando "+t+" segundos...");
            this.moveVelocity = v;
            yield return new WaitForSeconds(t);
            this.moveVelocity = vn;
            cond = false;
            Debug.Log("Acabou a espera");
        }
    }

}