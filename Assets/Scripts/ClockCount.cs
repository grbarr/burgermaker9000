using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClockCount : MonoBehaviour {

	public bool isCounting;
	public float counterTime;
    public float totalTime = 0;
	public float alarmTime;	// a ratio of the time to set off the alarm
    public Text counter;
    public Animator timeBonusAnimator;
    public Text timeBonusText;

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
			//this.alarmSound.Play(); // This doesn't work :(
		}

		//Update the timer
		if (isCounting) {
			currentTime -= Time.deltaTime;
            this.counter.text = (Mathf.Round(this.currentTime * 10) / 10).ToString();
		    if (this.currentTime <= 10) {
		        this.counter.color = Color.red;
            } else {
                this.counter.color = Color.black;
            }
		    totalTime += Time.deltaTime;
		}
		else {
			currentTime = counterTime;
			animator.Play("ClockRest");
			animator.SetBool("setAlarm",false);
		}

	}

    public void AddTime(float additionalTime) {


        if (additionalTime < 0) {
            this.timeBonusText.text = additionalTime.ToString();
            this.timeBonusAnimator.Play("Time_Penalty");
        } else if (additionalTime > 0) {
            this.timeBonusText.text = "+" + additionalTime.ToString();
            this.timeBonusAnimator.Play("Time_Bonus");
        }

        this.currentTime += additionalTime;
    }

}
