using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	// variable to rotation speed.
	public float RotationSpeed = 1f;

	// Start is called before the first frame update
	void Start()
	{
		// we want to add 1 to the total as we are a coin.
		CoinManager.Current.AddToCollection();
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
		if (other.tag == "Player")
		{
			CoinManager.Current.CollectCoin();

			Destroy(this.gameObject);
		}
	}
}
