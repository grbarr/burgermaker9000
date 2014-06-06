using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 40;
		
		// Draw a button to start the game
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Get yo burg' on!"
			)
			)
		{
			// On Click, load the first level.
			Application.LoadLevel("scene1");
		}
	}
}