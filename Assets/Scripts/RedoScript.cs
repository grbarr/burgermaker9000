using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RedoScript : MonoBehaviour {
	public AudioSource clickSound;

	public AudioSource[] resetSounds;

	public void playResetSound() {
		var sound = resetSounds [Random.Range (0, resetSounds.Length)];
		sound.Play();
	}
	
	void OnMouseDown() {
		GameController gameControl = GameController.Instance;
		gameControl.ClearPlayerBurger ();

		this.clickSound.Play ();
		playResetSound();
	}
}
