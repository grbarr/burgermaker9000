using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RedoScript : MonoBehaviour {
	public AudioSource clickSound; 
	public AudioSource resetSound1;
	
	void OnMouseDown() {
		GameController gameControl = GameController.Instance;
		gameControl.ClearPlayerBurger ();

		this.clickSound.Play ();
		this.resetSound1.Play ();
	}
}
