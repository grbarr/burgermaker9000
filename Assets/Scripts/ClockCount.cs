﻿using UnityEngine;
using System.Collections;

public class ClockCount : MonoBehaviour {

	public bool isCounting;
	public float counterTime;
	public float alarmTime;	// a ratio of the time to set off the alarm
	private float currentTime;
	private Animator animator;
	GameObject clockHand;

	public AudioSource alarmSound;

	// Use this for initialization
	void Start () {
		currentTime = counterTime;
		clockHand = GameObject.Find ("ClockHand");
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		//when the timer ends
		if (currentTime < 0) {
			isCounting = false;

			GameController gameControl = GameController.Instance;
			gameControl.showResults();
		}

		//Alarm goes
		if (currentTime / counterTime < alarmTime) {
			animator.SetBool("setAlarm",true);
			this.alarmSound.Play(); // This doesn't work :(
		}

		//Update the timer
		if (isCounting) {
			currentTime -= Time.deltaTime;
		}
		else {
			currentTime = counterTime;
			animator.Play("ClockRest");
			animator.SetBool("setAlarm",false);
		}

		//rotate the hand of the clock correctly
		float angle;
		if ( counterTime == 0f )
			angle = 0;
		else
			angle = - currentTime / counterTime * 360 + 720;
		clockHand.transform.localRotation = Quaternion.Euler (0, 0, angle);

	}

}
