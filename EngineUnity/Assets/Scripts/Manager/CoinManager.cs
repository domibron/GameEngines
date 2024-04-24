using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
	public static CoinManager Current;

	public int CoinAmmount = 0;
	public int CoinCount = 0;

	void Awake()
	{
		if (Current != null && Current != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Current = this;
		}
	}


	// Update is called once per frame
	void Update()
	{

	}

	public void AddToCollection()
	{
		CoinAmmount++;
	}

	public void CollectCoin()
	{
		CoinCount++;
	}
}
