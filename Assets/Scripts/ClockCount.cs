using UnityEngine;
using System.Collections;

public class ClockCount : MonoBehaviour {

	public bool isCounting;
	public float counterTime;
	private float currentTime;
	GameObject clockHand;

	// Use this for initialization
	void Start () {
		currentTime = counterTime;
		clockHand = GameObject.Find ("ClockHand");
	}
	
	// Update is called once per frame
	void Update () {
		//when the timer ends
		if (currentTime < 0) {
			isCounting = false;
		}

		//Update the timer
		if (isCounting) {
			currentTime -= Time.deltaTime;
		}
		else
			currentTime = counterTime;

		//rotate the hand of the clock correctly
		float angle;
		if ( counterTime == 0f )
			angle = 0;
		else
			angle = - currentTime / counterTime * 360;
		Debug.Log (angle);
		clockHand.transform.rotation = Quaternion.Euler (0, 0, angle);

	}
}
