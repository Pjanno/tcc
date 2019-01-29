using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

public float maxSpeed;
public float jumpForce;

private bool grounded;
private bool jumping;

private Rigidbody2D rb;
private Animator anim;
private SpriteRenderer sprite;

public Transform groundCheck;

void Start ()
{
	rb = GetComponent<Rigidbody2D> ();
	sprite = GetComponent<SpriteRenderer> ();
	anim = GetComponent<Animator> ();
}

void Update ()
{
	grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
	
	if (Input.GetButtonDown("Jump") && grounded)
	{
		jumping = true;
	}
}

void FixedUpdate ()
{
	float move = Input.GetAxis("Horizontal");
	rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y);

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

}