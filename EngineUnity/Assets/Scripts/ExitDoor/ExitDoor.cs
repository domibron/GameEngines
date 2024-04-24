using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
	public int LevelBuildIndex = 0;

	public ParticleSystem Confetti;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (CoinManager.Current.CoinCount >= CoinManager.Current.CoinAmmount && !Confetti.isPlaying)
		{
			Confetti.Play();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && CoinManager.Current.CoinCount >= CoinManager.Current.CoinAmmount)
		{
			SceneManager.LoadScene(LevelBuildIndex);
		}
	}
}
