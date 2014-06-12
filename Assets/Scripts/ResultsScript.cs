using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ResultsScript : MonoBehaviour {

	public float x, y, width, height;
	public string playerName = "Enter Name";
	const int maxNameLength = 9;
	public GUIStyle customStyle;
	public AudioSource[] finishSounds;
	private float newWidth, newHeight;

	// Use this for initialization
	void Start () {
		width *= Screen.width / Camera.main.orthographicSize * Camera.main.aspect;
		height *= Screen.height / Camera.main.orthographicSize;
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
		Vector3 enterNameWorldPosition = new Vector3 (x, y, 0);
		Rect enterNamePosition = new Rect (Camera.main.WorldToScreenPoint (enterNameWorldPosition).x,
		                                   Camera.main.WorldToScreenPoint(enterNameWorldPosition).y, width, height);
		if (playerName != "Enter Name") {
			playerName = GUI.TextField(enterNamePosition, playerName, maxNameLength, customStyle);
			playerName = Regex.Replace (playerName, @"[^a-zA-Z0-9]", "");
		}
		else
			playerName = GUI.TextField(enterNamePosition, playerName, customStyle);
	}
}
