using UnityEngine;
using System.Collections;

public class ScoreSave : MonoBehaviour {

    public int score;

    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    private static ScoreSave instance;
    public static ScoreSave Instance {
        get {
            if (ScoreSave.instance == null) {
                var go = GameObject.Find("HighscoreSave");
                if (go == null) {
                    go = new GameObject("HighscoreSave");
                    ScoreSave.instance = go.AddComponent<ScoreSave>();
                } else {
                    ScoreSave.instance = go.GetComponent<ScoreSave>();
                }
            }
            return ScoreSave.instance;
        }
    }
}
