using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
	// singleton.
	public static CoinManager Current;

	// total ammount of coins the player can collect.
	public int CoinTotal = 0;
	// current ammount of coins collected.
	public int CoinCount = 0;

	void Awake()
	{
		// if the singletop exsist then delete this.
		if (Current != null && Current != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			// else set the current to this.
			Current = this;
		}
	}

	// public function ton increase the ammount of total coins.
	public void AddToCollection()
	{
		CoinTotal++;
	}

	// add to colected coins.
	public void CollectCoin()
	{
		CoinCount++;
	}
}
