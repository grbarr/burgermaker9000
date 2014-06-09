using UnityEngine;
using System.Collections;

public class creditscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var go = GameObject.Find ("creditlist");
		go.guiText.text = "Jen Costa, Tina Chan, Nick Van Vugt,\n Tanner Rogalsky, Rebecca Dreezer,\n Christine Brual, Kaitlin Smith, Haven Szostak,\n Graham Barr";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
