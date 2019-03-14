using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habbit : MonoBehaviour {

	public float speed;
	public float stoppingDistance;
	private Transform target;
	public float jumpForce;
	private bool grounded;
	private bool jumping;
	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sprite;
	public Transform checkGround;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		rb = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position, target.position) > stoppingDistance){
			transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}
void FixedUpdate ()
{
	float move = Input.GetAxis("Horizontal");
	
	if ((move > 0f && sprite.flipX) || (move < 0f && !sprite.flipX))
	{
		Flip();
	}

	if (jumping) 
	{
		rb.AddForce(new Vector2(0f, jumpForce));
		jumping = false;
	}

	grounded = Physics2D.Linecast(transform.position, checkGround.position, 1 << LayerMask.NameToLayer ("Ground"));

	if (Input.GetButtonDown("Jump") && grounded)
	{
		jumping = true;
	}
}
	void Flip ()
	{
		sprite.flipX = !sprite.flipX;
	}
}
