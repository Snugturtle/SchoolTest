using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private int coinTotal;
	private HUDController hud;

	void Awake(){
		Debug.Log ("# of scenes: " + SceneManager.sceneCountInBuildSettings);
		//Singleton instantiation
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Debug.Log ("Singleton already instantiated: destroying new instance.");
			Destroy (gameObject);
		}
	}

	void Start(){
		hud = GetComponent<HUDController> ();
	}

	public void LoadScene(int scene){
		if (0 <= scene && scene < SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadSceneAsync (scene);
			if (hud.isPaused) {
				hud.toggleMenu ();
			}
		} else {
			Debug.Log ("Scene not in build");
		}
	}

	public void AddCoin(){
		coinTotal++;
	}

	public int GetCoins(){
		return coinTotal;
	}
}
