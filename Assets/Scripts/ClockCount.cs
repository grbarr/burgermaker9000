using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ClockCount : MonoBehaviour {

	public bool isCounting;
	public float counterTime;
    public float totalTime = 0;
	public float alarmTime;	// a ratio of the time to set off the alarm
    public bool paused;
    public Text counter;
    public GameObject rewardObject;
    public GameObject Canvas;

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
            this.counter.color = Color.red;
			animator.SetBool("setAlarm",true);

            if(!alarmSound.isPlaying)
			    this.alarmSound.Play();
        } else {
            this.alarmSound.Stop();
        }

		//Update the timer
        if (!this.paused) {
		    if (isCounting) {
			    currentTime -= Time.deltaTime;
                this.counter.text = (Mathf.Round(this.currentTime * 10) / 10).ToString();
		        totalTime += Time.deltaTime;
		    }
		    else {
			    currentTime = counterTime;
			    animator.Play("ClockRest");
			    animator.SetBool("setAlarm",false);
		    }
        } else {
            animator.Play("ClockRest");
            animator.SetBool("setAlarm", false);
            this.alarmSound.Stop();
        }
	}

    public IEnumerator AddTime(float additionalTime) {

        if(this.Canvas.transform.childCount > 0)
            yield return new WaitForSeconds(.5f);

        this.currentTime += additionalTime;

        Color temp = this.counter.color;

        GameObject bonusTextGO = (GameObject)Instantiate(rewardObject);
        bonusTextGO.transform.parent = this.Canvas.transform;

        Animator timeBonusAnimator = bonusTextGO.gameObject.GetComponent<Animator>();
        Text timeBonusText = bonusTextGO.GetComponentInChildren<Text>();

        if (additionalTime < 0) {
            timeBonusText.text = additionalTime.ToString();
            timeBonusAnimator.Play("Time_Penalty");
            this.counter.color = Color.red;
        } else if (additionalTime > 0) {
            timeBonusText.text = "+" + additionalTime.ToString();
            timeBonusAnimator.Play("Time_Bonus");
            this.counter.color = Color.green;
        }

        Destroy(bonusTextGO, 1.15f);

        animator.SetBool("setAlarm", true);
        yield return new WaitForSeconds(1f);
        animator.Play("ClockRest");
        animator.SetBool("setAlarm", false);

        if (this.currentTime < 10) {
            this.counter.color = Color.red;
        } else {
            this.counter.color = Color.black;
        }

    }

    public void pause() {
        this.paused = true;
    }

    public void start() {
        this.paused = false;
    }

}
