using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
	Name           : Makoto Wilson
	Student Number: 100810278
*/

public class HUDController : MonoBehaviour {
	// This class controls the hud element of the game

	[SerializeField]
	Text pointsLabel = null;
	[SerializeField]
	Text livesLabel = null;
	[SerializeField]
	Text score = null;
	[SerializeField]
	Text gameOverLabel = null;

	//reset button
	[SerializeField]
	Button resetBtn = null;

	//player object
	[SerializeField]
	GameObject player = null;

	//meteor object
	[SerializeField]
	GameObject meteor = null;

	// Use this for initialization
	void Start () {
		Player.Instance._hud = this;
		init ();

	}

	public void init(){
		//resets the HUD
		pointsLabel.gameObject.SetActive (true);
		livesLabel.gameObject.SetActive (true);
		player.gameObject.SetActive (true);
		//meteor.gameObject.SetActive (true);

		Player.Instance.Lives = 3;
		Player.Instance.Points = 0;

		resetBtn.gameObject.SetActive (false);
		gameOverLabel.gameObject.SetActive (false);
		score.gameObject.SetActive (false);

	}

	public void gameOver(){
		//displays gameover screen

		//disables player and displays reset button
		pointsLabel.gameObject.SetActive (false);
		livesLabel.gameObject.SetActive (false);
		player.gameObject.SetActive (false);
		//meteor.gameObject.SetActive (false);

		resetBtn.gameObject.SetActive (true);
		gameOverLabel.gameObject.SetActive (true);
		score.gameObject.SetActive (true);

		score.text = "Score: " + Player.Instance.Points;
	
	}
	
	public void updateDisplay(){
		//updates player health and life display
		pointsLabel.text = "Points: " + Player.Instance.Points;
		livesLabel.text = "Life: " + Player.Instance.Lives;
	}

	public void RestartButtonClick(){
		//resets HUD and reloads the level
		init ();
		Application.LoadLevel (Application.loadedLevel);
	}
}
