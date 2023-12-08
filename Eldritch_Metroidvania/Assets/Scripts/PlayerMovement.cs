using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	private Rigidbody2D rb;

	public float MOVE_SPEED = 1f;
	public float MAX_SPEED = 10f;
	public float BUTTON_PRESS_TIME = 0.3f;
	public float FIXED_JUMP_HEIGHT = 1;
	public float JUMP_CANCEL_RATE = 100;
	public float JUMP_GRAVITY_SCALE = 1;
	public float FALL_GRAVITY_SCALE = 10;

	float jumpTime;
	bool jumping;
	bool jumpCancelled;
	bool onGround;


	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;
		rb.gravityScale = FALL_GRAVITY_SCALE;
		jumping = false;
		jumpCancelled = false;
		jumpTime = 0;
		onGround = false;
	}

	private void Update()
	{

		Walk();
		Jump();

		
	}

	private void Walk()
	{
		if(Math.Abs(rb.velocity.x) < MAX_SPEED)
		{
			rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * MOVE_SPEED, 0), ForceMode2D.Impulse);
		}
		else
		{
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MAX_SPEED, rb.velocity.y);
		}
		
		
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && onGround)
		{
			float jumpForce = Mathf.Sqrt(FIXED_JUMP_HEIGHT * -2 * (Physics2D.gravity.y * rb.gravityScale));
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			rb.gravityScale = JUMP_GRAVITY_SCALE;
			jumping = true;
			onGround = false;
			jumpCancelled = false;
			jumpTime = 0;
		}
		if (jumping)
		{
			jumpTime += Time.deltaTime;
			if (Input.GetButtonUp("Jump"))
			{
				jumpCancelled = true;
				rb.gravityScale = FALL_GRAVITY_SCALE;
			}
			if (jumpTime > BUTTON_PRESS_TIME)
			{
				jumping = false;
				rb.gravityScale = FALL_GRAVITY_SCALE;
			}
		}

		if(!onGround) 
		{
			if(rb.velocity.y == 0)
			{
				onGround = true;
			}
		}


	}

	private void FixedUpdate()
	{
		if (jumpCancelled && jumping && rb.velocity.y > 0)
		{
			rb.AddForce(Vector2.down * JUMP_CANCEL_RATE);
		}
	}
}


