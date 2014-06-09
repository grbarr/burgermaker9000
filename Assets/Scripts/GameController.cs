using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public List<string> burger = new List<string>();
	public List<string> playerburger = new List<string>();
	private int burgerScore = 0;

	public ClockCount clock;

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
		ClearBurger();
		GenerateBurger();

		// start the timer
		Debug.Log (this.clock);
		this.clock.isCounting = true;
	}

	void Update() {
		if (CheckBurgersMatch()) {
			incrementBurgerScore();
			Debug.Log("Burger Match!");
			ClearPlayerBurger();
			ClearBurger();
			GenerateBurger();
		}

		if (playerburger.Count > 8) { 
			ClearPlayerBurger();
		}
	}

	public bool CheckBurgersMatch() {
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
			go.transform.localPosition = new Vector3(0f, index * 0.9f, 0f);
			sr.sortingOrder = index;

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
				GameController.instance = GameObject.Find("GameController").GetComponent<GameController>();
			}
			return GameController.instance;
		}
	}
}
