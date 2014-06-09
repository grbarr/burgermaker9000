using UnityEngine;
using System.Collections;

public class HighscorePageController : MonoBehaviour {

	HighscoreController highscore;

	// Use this for initialization
	void Start () {
		//import highscores
		highscore = GameObject.Find ("highscoreController").GetComponent<HighscoreController> ();
		updateScores ();
	}

	void updateScores () {
		highscore.loadScores ();
		Highscore curPlayer;
		int i = 0;
		foreach(Transform child in transform) {
			curPlayer = highscore.playerAt(i);
			if (curPlayer != null)
				child.GetComponent<GUIText>().text = (i+1).ToString() + ". " + curPlayer.name + " " + curPlayer.score;
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
