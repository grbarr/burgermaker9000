using UnityEngine;
using System.Collections;

public class keepAlive : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (this.gameObject);
	}
}
