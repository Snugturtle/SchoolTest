using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
	public float rotationSpeed = 45;



	void Update () {
		transform.Rotate (Vector3.up * rotationSpeed *  Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")){
			this.gameObject.SetActive(false);
			GameManager.instance.AddCoin ();
			Debug.Log("Coins: " + GameManager.instance.GetCoins());
		}
	}
}
