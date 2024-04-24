using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	public Transform CameraHolder;

	public float Sense = 1f;

	// need to store the current rotation.
	private float _yRotation;

	// Start is called before the first frame update
	void Start()
	{
		// hide the cursor. (should be in its own script).
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		HandleLook();
	}

	void HandleLook()
	{
		// turn the mouse inputs into a 2d vetor.
		Vector2 mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		// subtract from the current y with the mouse y. (because we dont like inverted mouse :vomit:)
		_yRotation -= mouseMove.y * Sense;

		// Clamp the Y rotation so the player don't snap their neck.s
		_yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

		// rotate the body by mouse x.
		transform.Rotate(Vector3.up * mouseMove.x * Sense);

		// doing 0 means that those axis are locked. IK.
		// Set the local y rotation to the camera.
		CameraHolder.localRotation = Quaternion.Euler(_yRotation, 0, 0);
	}
}
