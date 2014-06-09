using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour {
	public AudioSource clickSound; 

	void OnGUI() {
		const int buttonWidth = 120;
		const int buttonHeight = 40;

		// Draw a button to start the game
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(5 * Screen.height / 6) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
				"Get yo burg' on!"
			)
		) {
			// On Click, load the first level.
			this.clickSound.Play();
			Application.LoadLevel("scene1");
		}
	}
}