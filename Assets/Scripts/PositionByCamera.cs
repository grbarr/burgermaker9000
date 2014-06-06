using UnityEngine;
using System.Collections;

public class PositionByCamera : MonoBehaviour {

	public enum ScreenEdge {LEFT, RIGHT, TOP, BOTTOM, TOPRIGHT};
	public ScreenEdge screenEdge;
	public float yOffset;
	public float xOffset;

	// Use this for initialization
	void Start () {
		// 1
		Vector3 newPosition = transform.position;
		Camera camera = Camera.main;
		
		// 2
		switch(screenEdge)
		{
			// 3
		case ScreenEdge.RIGHT:
			newPosition.x = camera.aspect * camera.orthographicSize + xOffset;
			newPosition.y = yOffset;
			break;
			
			// 4
		case ScreenEdge.TOP:
			newPosition.y = camera.orthographicSize + yOffset;
			newPosition.x = xOffset;
			break;

		case ScreenEdge.TOPRIGHT:
			newPosition.x = camera.aspect * camera.orthographicSize + xOffset;
			newPosition.y = camera.orthographicSize + yOffset;
			break;
		}
		// 5
		transform.position = newPosition;
		//GameObject thisObject = GameObject.Find ("Clock");
		//Debug.Log (thisObject.GetComponent(PositionByCamera).xOffset);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
