using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// speeds
	public float SprintSpeed = 7f;

	public float WalkSpeed = 4f;

	public float JumpHeight = 4;

	public float Gravity = 9.81f;


	private CharacterController cc;

	private Vector3 velocity = Vector3.zero;

	private bool IsGrounded = false;

	// Start is called before the first frame update
	void Start()
	{
		// set the character controller variable.
		cc = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{

		// turns movmenet input into movement.
		HandleMovement(); // * does not use velocity! it uses cc.Move.

		// checks if the player is grounded.
		HandleGroundCheck();

		// sets the velocity to the respected gravity.
		HandleGravity(); // this changes the 

		// handles jumping.
		HandleJumping();

		// movesd
		cc.Move(velocity * Time.deltaTime);

	}

	void HandleMovement()
	{
		// get the vect of the input (we put the w and s in x and a and d in z).
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		// the finalMoveDir after all the math.
		Vector3 finalMoveDir = Vector3.zero;

		// if we are sprinting then multiply the move driection by sprint speed, otherwise by walk.
		if (Input.GetKey(KeyCode.LeftShift))
		{
			finalMoveDir = moveDir.normalized * SprintSpeed;
		}
		else
		{
			finalMoveDir = moveDir.normalized * WalkSpeed;
		}

		// convert the movement based on the character's rotation.
		Vector3 move = transform.right * finalMoveDir.x + transform.forward * finalMoveDir.z;

		// move the character.
		cc.Move(move * Time.deltaTime);
	}

	void HandleGroundCheck()
	{
		// get the bottom of the player by getting the cenre and then lower by half of the height on the y.
		Vector3 bottomOfPlayer = new Vector3(transform.position.x, transform.position.y - cc.height / 2, transform.position.z);

		// two checks, a raycast and a speare check. ~(1 << 3) - any layer not the player layer.
		IsGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f) || Physics.CheckSphere(bottomOfPlayer, cc.radius * 0.9f, ~(1 << 3));
	}

	void HandleGravity()
	{
		// if we are grounded then the y velocity should be -2f.
		if (IsGrounded && velocity.y < -2f) velocity.y = -2f;
		// else we add gravirt to the y velocity over time.
		else velocity.y += -Gravity * Time.deltaTime;

	}

	void HandleJumping()
	{
		// if we press space and are grounded then add force to y velocuty.
		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
		{
			// math to get the force required for the jump height.
			velocity.y += Mathf.Sqrt(JumpHeight * -2f * (-Gravity));
		}
	}
}


