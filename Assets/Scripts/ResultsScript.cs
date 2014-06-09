using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ResultsScript : MonoBehaviour {

	public Rect enterNamePosition;
	public string playerName = "Enter Name";
	const int maxNameLength = 9;
	public GUIStyle customStyle;
	public AudioSource[] finishSounds;

	// Use this for initialization
	void Start () {
		GameController gameControl = GameController.Instance;
		if (gameControl != null) {
			var score = gameControl.getBurgerScore ();
			// display score
			var scoreText = GameObject.Find ("ScoreText");
			scoreText.guiText.text = score.ToString();

			playFinishSound();
		}
	}
	
	public void playFinishSound() {
		var sound = finishSounds [Random.Range (0, finishSounds.Length)];
		sound.Play();
	}

	void OnGUI () {
		if (playerName != "Enter Name") {
			playerName = GUI.TextField(enterNamePosition, playerName, maxNameLength, customStyle);
			playerName = Regex.Replace (playerName, @"[^a-zA-Z0-9]", "");
		}
		else
			playerName = GUI.TextField(enterNamePosition, playerName, customStyle);
	}
}
