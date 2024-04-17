using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private CharacterController cc;

	public float SprintSpeed = 7f;

	public float WalkSpeed = 4f;

	public float JumpHeight = 4;

	public float Gravity = 9.81f;

	private Vector3 velocity = Vector3.zero;

	private bool IsGrounded = false;

	// Start is called before the first frame update
	void Start()
	{
		cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{


		HandleMovement(); // * does not use velocity!

		HandleGroundCheck();

		HandleGravity();

		HandleJumping();

		cc.Move(velocity * Time.deltaTime);

	}

	void HandleMovement()
	{
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		Vector3 finalMoveDir = Vector3.zero;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			finalMoveDir = moveDir.normalized * SprintSpeed;
		}
		else
		{
			finalMoveDir = moveDir.normalized * WalkSpeed;
		}

		Vector3 move = transform.right * finalMoveDir.x + transform.forward * finalMoveDir.z;

		cc.Move(move * Time.deltaTime);
	}

	void HandleGroundCheck()
	{
		IsGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
	}

	void HandleGravity()
	{
		if (IsGrounded && velocity.y < -2f) velocity.y = -2f;
		else velocity.y += -Gravity * Time.deltaTime;

	}

	void HandleJumping()
	{
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			velocity.y += Mathf.Sqrt(JumpHeight * -2f * (-Gravity));
		}
	}
}


