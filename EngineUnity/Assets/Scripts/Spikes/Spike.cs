using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
	// when the player touches the spike then reload the current scene.
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
