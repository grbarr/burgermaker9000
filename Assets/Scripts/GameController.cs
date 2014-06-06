﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GenerateBurger();
	}

	void GenerateBurger() {
		string[] ingredients = new string[9] {"lettuce", "tomato", "patty", "pickles", "cheese", "patty", "patty", "patty", "patty",};
		int num_ingredients = Random.Range(1, 5);
		List<string> burger = new List<string>();

		burger.Add ("bottom_bun");

		for (int i = 0; i < num_ingredients; i++) {
			string ingredient = ingredients[Random.Range(0, 4)];
			Debug.Log("Adding " + ingredient + " to burger");
			burger.Add(ingredient);
		}

		burger.Add ("top_bun");
		Debug.Log("Buger looks like: " + burger);
	}
}