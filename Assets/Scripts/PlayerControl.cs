using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerControl : MonoBehaviour {

    public float maxSpeed;
    public float jumpForce;
    private bool grounded;
    private bool jumping;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public Transform groundCheck;
    private float tempo;
    private int segundos;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator> ();
    }

    void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

        anim.SetFloat("velY", rb.velocity.y);

        if (Input.GetButtonDown ("Jump") && grounded) {
            jumping = true;
            
        }
    }

    void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

        if (move != 0)
        {
            this.gameObject.GetComponent<Animator>().SetBool("movendo", true);
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("movendo", false);
        }

	    //Se movimento for menor que zero (ou seja, pra esquerda) e o boneco estiver virado p/ dir ele faz o flip
	    //Se movimento for maior que zero(ou seja, para direita) e o boneco estiver virado p/ esq ele da o flip
        if ((move > 0f && sprite.flipX) || (move < 0f && !sprite.flipX))
        {
            Flip();
        }

        if (jumping) 
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
    }

    void Flip ()
    {
        sprite.flipX = !sprite.flipX;
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
            var vn = this.maxSpeed;
            Debug.Log("Esperando "+t+" segundos...");
            this.maxSpeed = v;
            yield return new WaitForSeconds(t);
            this.maxSpeed = vn;
            cond = false;
            Debug.Log("Acabou a espera");
        }
    }

}