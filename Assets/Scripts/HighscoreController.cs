using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Highscore : IComparable<Highscore> {
	public string name;
	public int score;
	public Highscore (string name, int score) {
		this.name = name;
		this.score = score;
	}

	public int CompareTo(Highscore highscore) {
		return score.CompareTo (highscore.score);
	}

}

public class HighscoreController : MonoBehaviour {

	private List<Highscore> scores = new List<Highscore>();

	public void addScore(string name, int score) {
		Highscore curScore = new Highscore (name, score);
		scores.Add (curScore);
		scores.Sort ();
	}

	public void clearScores() {
		scores.Clear ();
	}

	public Highscore playerAt(int index) {
		return scores[index];
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
