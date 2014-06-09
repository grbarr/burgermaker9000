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
		Application.LoadLevel("menu_scene");
	}
}
