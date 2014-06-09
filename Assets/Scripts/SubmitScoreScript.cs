using UnityEngine;
using System.Collections;

public class SubmitScoreScript : MonoBehaviour {

	string userName;
	int userScore;
	GameController gameControl;

	void OnMouseDown() {
		userName = GameObject.Find ("GUI Script").GetComponent<ResultsScript> ().playerName;
		if (gameControl == null) {
			Debug.Log("No game object in scene!");
			return;
		}
		userScore = gameControl.getBurgerScore ();
		HighscoreController highscore = GameObject.Find ("highscoreController").GetComponent<HighscoreController> ();
		highscore.loadScores ();
		highscore.addScore (userName, userScore);
		highscore.saveScores ();
		Debug.Log ("added " + userName + "'s score of " + userScore.ToString ());
		// On Click, load the highscore page.
		DontDestroyOnLoad (GameObject.Find ("highscoreController"));
		Application.LoadLevel("highscore_scene");

	}
	// Use this for initialization
	void Start () {
		gameControl = GameController.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
