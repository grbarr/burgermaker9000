using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {
	public List<string> burger = new List<string>();
	public List<string> playerburger = new List<string>();
    public float randomizeInterval;
    public float failureTimePenalty;
    public float successTimeReward;
    public Animator randomizeAnimator;
    public bool randomizing = false;

	private int burgerScore = 0;
	private bool burgerlock = false;

	public AudioSource[] startSounds;
	public AudioSource[] successSounds;

    public List<AddBurgerPart> Toppings;

	public ClockCount clock;

    public int streak = 0;
    public Text streakText;
    public Animator streakAnimator;
    public int streakBonus;
    public int streakInterval;

    public float lastCheck = 0;

	public void playStartSound() {
		var sound = startSounds[Random.Range(0, startSounds.Length)];
		sound.Play();
	}

	int successSkip = 0;
	int nextMember = 0;
	int successPrime = 0;

	public void playSuccessSound() {
		Debug.Log (successSounds.Length);

		Debug.Log (successPrime);

		while (successSkip % successPrime == 0) {
			// Generate three random positive, non-zero numbers
			int ra = Random.Range(1, successPrime);
			int rb = Random.Range(1, successPrime);
			int rc = Random.Range(1, successPrime);
			successSkip = ra * successSounds.Length * successSounds.Length + rb * successSounds.Length + rc;
		}

		do {
			nextMember += successSkip;
			nextMember %= successPrime;
		} while (nextMember <= 0 || nextMember > successSounds.Length);

		Debug.Log (nextMember);
		var sound = successSounds [nextMember - 1];
		sound.Play();
	}

	// The following functions keep track of the number of burgers
	public IEnumerator incrementBurgerScore () {
		burgerScore++;
        StartCoroutine(this.clock.AddTime(this.successTimeReward));

        this.streak++;
        if ((this.streak != 0) && ((this.streak % this.streakInterval) == 0)) {
            yield return new WaitForSeconds(0.5f);
            this.streakAnimator.Play("Streak");
            StartCoroutine(this.clock.AddTime((this.streak / this.streakInterval) * this.streakBonus));
        }
        yield return null;
	}

	public void incrementBurgerScore(int n) {
		burgerScore += n;
	}

	public int getBurgerScore () {
		return burgerScore;
	}

	public void ResetBurgerScore () {
		burgerScore = 0;
	}

	void Start() {
		GameObject.Find ("checkmark").renderer.enabled = false;

		ClearBurger();
		GenerateBurger();

		// start the timer
		Debug.Log (this.clock);
		this.clock.isCounting = true;

		successPrime = 11;
		playStartSound();
	}

	void Update() {
		if (CheckBurgersMatch()) {
			burgerlock = true;
            StartCoroutine(incrementBurgerScore());

			var text = (GameObject.Find("paper pad text")).GetComponent<Text>();
			text.text = getBurgerScore().ToString();

			playSuccessSound();

			StartCoroutine (newburger(true));
		}

        if(streakText)
		    streakText.text = this.streak.ToString();
		

		if (playerburger.Count > 8) { 
			ClearPlayerBurger();
		}

	    if ( this.clock && ((this.clock.totalTime - this.lastCheck) >= this.randomizeInterval) ) {
            if(!this.randomizing)
                StartCoroutine(this.RandomizeToppings());
	    }
	}
	public IEnumerator newburger(bool correct) {

        if (correct) {
		    GameObject.Find ("checkmark").renderer.enabled = true;
        } else {
            // graham heres where to show the X just set it up 
            // like the check mark is set up and then insert the same code
        }

		yield return new WaitForSeconds (0.5f);
		ClearPlayerBurger();
		ClearBurger();
		GenerateBurger();
		burgerlock = false;
		GameObject.Find ("checkmark").renderer.enabled = false;
	}

	public bool CheckBurgersMatch() {
		if (burgerlock == true) {
			return false;
		}
		if (playerburger.Count != burger.Count) {
			return false;
		}
		for(int i = 0; i < burger.Count; i++) {
			if(!burger[i].Equals(playerburger[i])) {
				return false;
			}
		}
		return true;
	}

	public void GenerateBurger() {
		string[] ingredients = new string[9] {"lettuce", "tomato", "patty", "pickles", "cheese", "patty", "patty", "patty", "patty",};
		int num_ingredients = Random.Range(1, 6);

		burger.Add ("bun_bottom");

		for (int i = 0; i < num_ingredients; i++) {
			string ingredient = ingredients[Random.Range(0, 8)];
			burger.Add(ingredient);
		}

		burger.Add ("bun_top");

		// print burger and display on screen
//		for (var i = 0; i < burger.Count; i++) {
//			Debug.Log (burger[i].ToString());
//		}
		DisplayGeneratedBurger();
	}

	public void DisplayGeneratedBurger() {
		var burger_object = GameObject.Find ("Burger");
		int index = 1;

		foreach (string burg_ing in burger) {
			var texture = Resources.Load<Texture2D>("burger_parts/" + burg_ing);
			Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			GameObject go = new GameObject(burg_ing);
			SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
			sr.sprite = sprite;

			// TODO: make sure layering of toppings looks correct
			go.transform.parent = burger_object.transform;
			go.transform.localPosition = new Vector3(0f, index * 0.7f, 0f);
			sr.sortingOrder = index;
			go.transform.localScale = new Vector3(0.6f,0.6f,1f);

			index++;
		}
	}

	public void ClearBurger() {
		burger.Clear();
		var burger_object = GameObject.Find ("Burger");
		if (!burger_object)
			return;
		foreach (Transform child in burger_object.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void ClearPlayerBurger() {
		playerburger.Clear();
		var player_burger_object = GameObject.Find ("PlayerBurger");
		if (player_burger_object != null) {
			foreach (Transform child in player_burger_object.transform) {
				GameObject.Destroy (child.gameObject);
			}
		}
	}

	public void showResults() {
        ScoreSave.Instance.score = this.getBurgerScore();
		Application.LoadLevel("results_scene");
	}

	private static GameController instance;
	public static GameController Instance {
		get {
			if (GameController.instance == null){
				var go = GameObject.Find("GameController");
				if (go == null) {
					go = new GameObject("GameController");
					GameController.instance = go.AddComponent<GameController>();
				} else {
					GameController.instance = go.GetComponent<GameController>();
				}
			}
			return GameController.instance;
		}
	}

    [ContextMenu("Randomize Toppings")]
    public IEnumerator RandomizeToppings() {

        this.clock.pause();
        this.randomizing = true;
        this.randomizeAnimator.Play("Randomize");

        yield return new WaitForSeconds(3f);

        for (int i = (this.Toppings.Count - 1); i >= 0; i--) {
            int randomIndex = Random.Range(0, i);

            string tempName = this.Toppings[i].gameObject.name;
            Sprite tempSprite = this.Toppings[i].gameObject.GetComponent<SpriteRenderer>().sprite;

            this.Toppings[i].ChangeTopping(this.Toppings[randomIndex].gameObject.name, this.Toppings[randomIndex].GetComponent<SpriteRenderer>().sprite);
            this.Toppings[randomIndex].ChangeTopping(tempName, tempSprite);
        }

        lastCheck = clock.totalTime;
        this.clock.start();
        this.randomizing = false;
    }
}
