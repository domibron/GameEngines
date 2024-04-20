using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
	public int LevelBuildIndex = 0;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && CoinManager.Current.CoinCount >= CoinManager.Current.CoinAmmount)
		{
			SceneManager.LoadScene(LevelBuildIndex);
		}
	}
}
