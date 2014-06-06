﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public List<string> burger = new List<string>();
	
	public void GenerateBurger() {
		string[] ingredients = new string[9] {"lettuce", "tomato", "patty", "pickles", "cheese", "patty", "patty", "patty", "patty",};
		int num_ingredients = Random.Range(1, 5);

		burger.Add ("bottom_bun");

		for (int i = 0; i < num_ingredients; i++) {
			string ingredient = ingredients[Random.Range(0, 4)];
			Debug.Log("Adding " + ingredient + " to burger");
			burger.Add(ingredient);
		}

		burger.Add ("top_bun");
		Debug.Log("Buger looks like:");
		foreach(string burg_ing in burger) {
			Debug.Log(burg_ing);
		}
	}
}
