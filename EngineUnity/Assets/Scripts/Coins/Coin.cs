using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// variable to rotation speed.
	public float RotationSpeed = 1f;

	// a place to store the audio source.
	private AudioSource _audioSource;

	private bool _beenCollected = false;

	// Start is called before the first frame update
	void Start()
	{
		// we want to add 1 to the total as we are a coin.
		CoinManager.Current.AddToCollection();

		// store the referance to the audio source.
		_audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		// rotate the delicious coin.
		transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
	}

	// if the player toches the coin, increase coins collected and destroy this object
	// (we dont want to be able to keep collecting the coin).
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !_beenCollected)
		{
			// stops the player of collecting the coin again.
			_beenCollected = true;

			// collect the coin.
			CoinManager.Current.CollectCoin();

			// play the audio clip
			_audioSource.Play();

			// this causes the coin to persist on screen for a little bit.
			// we want to destory after the audio clip.
			StartCoroutine(WaitBeforeDestroying(_audioSource.clip.length));
		}
	}

	// delays the destroy.
	IEnumerator WaitBeforeDestroying(float time)
	{
		yield return new WaitForSeconds(time);

		Destroy(this.gameObject);
	}
}
