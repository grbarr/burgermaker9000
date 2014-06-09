using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//structure to hold each player's score information

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

	//functions to add, clear, save, load, and explore the highscore table
	//make sure player names in the highscore table to not contain the characters '#' or '*'

	public void addScore(string name, int score) {
		Highscore curScore = new Highscore (name, score);
		scores.Add (curScore);
		scores.Sort ();
	}

	public void clearScores() {
		scores.Clear ();
	}

	public Highscore playerAt(int index) {
		int size = scores.Count;
		if (index > size - 1)
			return null;
		return scores[size - index - 1];
	}

	public void saveScores () {
		int i = 0;
		string toSave = "";
		foreach(Highscore player in scores) {
			toSave += player.name + "#" + player.score.ToString();
			if (i != scores.Count - 1)
				toSave += "*";
			i++;
		}
		PlayerPrefs.SetString ("Highscores", toSave);
	}

	public void loadScores () {
		string toLoad = PlayerPrefs.GetString ("Highscores");
		string [] loadedArray = toLoad.Split ("*".ToCharArray());
		string[] curUser;
		clearScores ();
		for (int i = 0; i < loadedArray.Length; i++) {
			if (loadedArray[i] != "") {
				curUser = loadedArray[i].Split("#".ToCharArray());
				addScore(curUser[0],System.Int32.Parse(curUser[1]));
			}
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
