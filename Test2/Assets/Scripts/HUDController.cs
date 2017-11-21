using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour {
	public Text pauseText;
	public bool isPaused = false;

	//Rects for GUI labels and buttons
	public Rect menuRect = new Rect (10f, 10f, 50f, 50f);
	public Rect nextSceneRect = new Rect (280f, 100f, 120f, 60f);
	public Rect prevSceneRect = new Rect (280f, 170f, 120f, 60f);
	public Rect coinDispRect = new Rect(290f, 40f, 150f, 20f);

	void OnGUI(){
		//Current Scene Display
		GUI.Label(new Rect(290f, 10f, 150f, 20f), "Current Scene: " + (SceneManager.GetActiveScene().buildIndex + 1));

		//Coin count display
		GUI.Label(coinDispRect, "Coins: " + GameManager.instance.GetCoins());

		//###Pause menu content goes in here###
		if (isPaused) {
			//Button for next scene
			if (GUI.Button (nextSceneRect, "Next Scene")) {
				GameManager.instance.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}

			//Button for previous scene
			if (GUI.Button (prevSceneRect, "Previous Scene")) {
				GameManager.instance.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
			}
		}

		//Button for menu, same as [Escape] key
		if (GUI.Button (menuRect, "Menu")) {
			toggleMenu ();
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			toggleMenu ();
		}
	}

	public void toggleMenu(){
		if (!isPaused) {
			pauseText.text = "-Paused-";
			Time.timeScale = 0f;
			isPaused = true;
		} else {
			pauseText.text = "";
			Time.timeScale = 1f;
			isPaused = false;
		}
	}
}
