using UnityEngine;
using System.Collections;

public class SubmitScoreScript : MonoBehaviour {

	string userName;
	int userScore;

	void OnMouseDown() {
		userName = GameObject.Find ("GUI Script").GetComponent<ResultsScript> ().playerName;

        userScore = ScoreSave.Instance.score;
		HighscoreController highscore = GameObject.Find ("highscoreController").GetComponent<HighscoreController> ();
		highscore.loadScores ();
		highscore.addScore (userName, userScore);
		highscore.saveScores ();
		Debug.Log ("added " + userName + "'s score of " + userScore.ToString ());
		// On Click, load the highscore page.
		DontDestroyOnLoad (GameObject.Find ("highscoreController"));
		Application.LoadLevel("highscore_scene");

	}
}
