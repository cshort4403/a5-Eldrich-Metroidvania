using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	
	public float moveSpeed = 1f;
	public float jumpForce = 1f;

	private bool onGround = false;
	private Rigidbody2D rb2d;



	void Start()
	{
		
		rb2d = GetComponent<Rigidbody2D>();
		
	}

	void Update()
	{

		rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed,rb2d.velocity.y);

		

		if(onGround && Input.GetButtonDown("Jump"))
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
		}


	}
}

