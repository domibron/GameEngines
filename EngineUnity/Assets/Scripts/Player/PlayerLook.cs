using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	public Transform CameraHolder;

	public float Sense = 1f;

	private float _yRotation;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		HandleLook();
	}

	void HandleLook()
	{
		Vector2 mouseMove = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		_yRotation -= mouseMove.y;

		_yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

		transform.Rotate(Vector3.up * mouseMove.x * Sense);

		// doing 0 means that those axis are locked.
		CameraHolder.localRotation = Quaternion.Euler(_yRotation * Sense, 0, 0);
	}
}
