using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public float RotationSpeed = 1f;

	private float _currentRotation = 0f;

	// Start is called before the first frame update
	void Start()
	{
		CoinManager.Current.AddToCollection();
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			CoinManager.Current.CollectCoin();

			Destroy(this.gameObject);
		}
	}
}
