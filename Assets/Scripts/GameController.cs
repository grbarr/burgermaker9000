using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public List<string> burger = new List<string>();
	public List<string> playerburger = new List<string>();
	private int burgerScore = 0;
	private bool burgerlock = false;

	public AudioSource[] startSounds;

//	public AudioSource startSound1;
	public AudioSource successSound1;

	public ClockCount clock;

	public void playStartSound() {
		var sound = startSounds[Random.Range(0, startSounds.Length)];
		sound.Play();
	}

	// The following functions keep track of the number of burgers
	public void incrementBurgerScore () {
		burgerScore++;
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
		GameObject.DontDestroyOnLoad (this.gameObject);
		GameObject.Find ("checkmark").renderer.enabled = false;

		ClearBurger();
		GenerateBurger();

		// start the timer
		Debug.Log (this.clock);
		this.clock.isCounting = true;

		playStartSound();
	}

	void Update() {
		if (CheckBurgersMatch()) {
			burgerlock = true;
			incrementBurgerScore();
			var text = GameObject.Find("paper pad text");
			text.guiText.text = getBurgerScore().ToString();
			this.successSound1.Play();
			StartCoroutine (newburger());
		}

		if (playerburger.Count > 8) { 
			ClearPlayerBurger();
		}
	}
	IEnumerator newburger() {
		yield return new WaitForSeconds (0.2f);
		GameObject.Find ("checkmark").renderer.enabled = true;
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
		foreach (Transform child in burger_object.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void ClearPlayerBurger() {
		playerburger.Clear();
		var player_burger_object = GameObject.Find ("PlayerBurger");
		foreach (Transform child in player_burger_object.transform) {
			GameObject.Destroy(child.gameObject);
		}
	}

	public void showResults() {
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
}
