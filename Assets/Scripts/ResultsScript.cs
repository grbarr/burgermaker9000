using UnityEngine;
using System.Collections;

public class ResultsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameController gameControl = GameController.Instance;
		if (gameControl != null) {
			var score = gameControl.getBurgerScore ();
			// display score
			var scoreText = GameObject.Find ("ScoreText");
			scoreText.guiText.text = score.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
