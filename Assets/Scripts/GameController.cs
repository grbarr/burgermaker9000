using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public List<string> burger = new List<string>();
	private int burgerScore = 0;

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

	public void GenerateBurger() {
		string[] ingredients = new string[9] {"lettuce", "tomato", "patty", "pickles", "cheese", "patty", "patty", "patty", "patty",};
		int num_ingredients = Random.Range(1, 5);

		burger.Add ("bun_bottom");

		for (int i = 0; i < num_ingredients; i++) {
			string ingredient = ingredients[Random.Range(0, 4)];
			burger.Add(ingredient);
		}

		burger.Add ("bun_top");
//		Debug.Log("Buger looks like:");
//		foreach(string burg_ing in burger) {
//			Debug.Log(burg_ing);
//		}

		DisplayGeneratedBurger();
	}

	public void DisplayGeneratedBurger() {
		var burger_object = GameObject.Find ("burger");

		foreach (string burg_ing in burger) {
			var texture = Resources.Load<Texture2D>("burger_parts/" + burg_ing);
			Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			Debug.Log(sprite);
			GameObject go = new GameObject(burg_ing);
			GameObject.DontDestroyOnLoad(go);
			SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
			sr.sprite = sprite;
		}
	}
}
