using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AddBurgerPart : MonoBehaviour {
	public AudioSource clickSound; 

	void OnMouseDown() {
		var burg_ing = this.gameObject.name;
		GameController gameControl = GameController.Instance;
		gameControl.playerburger.Add (burg_ing);

	    if ((gameControl.playerburger.Count - 1) >= gameControl.burger.Count) {
            gameControl.clock.AddTime(-10);
	        gameControl.streak = 0;
            StartCoroutine(gameControl.newburger());
	    }
	    else if (gameControl.playerburger.Last() != gameControl.burger[gameControl.playerburger.Count - 1]) {
	        gameControl.clock.AddTime(-10);
            gameControl.streak = 0;
            StartCoroutine(gameControl.newburger());
	    }

		var player_len = gameControl.playerburger.Count;

		var player_burger = GameObject.Find ("PlayerBurger");
		var texture = Resources.Load<Texture2D>("burger_parts/" + burg_ing);
		Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		GameObject go = new GameObject(burg_ing);
		SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
		sr.sprite = sprite;

		this.clickSound.Play();
		
		go.transform.parent = player_burger.transform;
		go.transform.localPosition = new Vector3(0f, player_len * 0.6f, 0f);
		sr.sortingOrder = 0;
	}

    public void ChangeTopping(string name, Sprite image)
    {
        this.gameObject.name = name;
        SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
        if (sr)
            sr.sprite = image;
    }
}
