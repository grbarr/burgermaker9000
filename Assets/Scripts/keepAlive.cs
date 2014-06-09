using UnityEngine;
using System.Collections;

public class keepAlive : MonoBehaviour {

	public static bool started = false;

	// Use this for initialization
	void Start () {
		if (keepAlive.started) {
			GameObject.Destroy(this.gameObject);
			return;
		}
		GameObject.DontDestroyOnLoad (this.gameObject);
		keepAlive.started = true;
	}
}
