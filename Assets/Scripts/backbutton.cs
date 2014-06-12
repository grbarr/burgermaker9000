using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
public class backbutton : MonoBehaviour {
	public AudioSource clickSound; 
	
	void OnMouseDown() {
		// On Click, load the first level.
		this.clickSound.Play();
		GameObject gameController = GameObject.Find ("GameController");
		if (gameController)
			GameObject.Destroy(gameController);
		Application.LoadLevel("menu_scene");
	}
}
