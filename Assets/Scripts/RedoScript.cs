using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RedoScript : MonoBehaviour {
	public AudioSource clickSound; 
	
	void OnMouseDown() {
		GameController gameControl = GameController.Instance;
		gameControl.ClearPlayerBurger ();
	}
}
