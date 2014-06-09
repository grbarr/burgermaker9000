using UnityEngine;
using System.Collections;

/// <summary>
/// Title screen script
/// </summary>
public class gotocreditscript : MonoBehaviour {
	public AudioSource clickSound; 
	
	void OnMouseDown() {
		// On Click, load the first level.
		this.clickSound.Play();
		Application.LoadLevel("credits_scene");
	}
}