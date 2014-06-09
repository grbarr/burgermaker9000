using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddBurgerPart : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		var burg_ing = this.gameObject.name;
		GameObject playerBurger = GameObject.Find("PlayerBurger");
		GameController gameControl = GameController.Instance;
		gameControl.playerburger.Add (burg_ing);
		var player_len = gameControl.playerburger.Count;

		var player_burger = GameObject.Find ("PlayerBurger");
		var texture = Resources.Load<Texture2D>("burger_parts/" + burg_ing);
		Debug.Log (this.gameObject.name);
		Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		GameObject go = new GameObject(burg_ing);
		SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
		sr.sprite = sprite;
		
		go.transform.parent = player_burger.transform;
		go.transform.localPosition = new Vector3(0f, player_len * 0.1f, 0f);
		sr.sortingOrder = 0;
	}
}
