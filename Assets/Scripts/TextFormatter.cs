using UnityEngine;
using System.Collections;

public class TextFormatter : MonoBehaviour {
	public static Rect FormatGuiTextArea(GUIText guiText)
	{
		string[] words = guiText.text.Split(' ');
		string result = "";
		Rect textArea = new Rect();
		
		for(int i = 0; i < words.Length; i++)
		{
			guiText.text = (result + words[i] + "\n");
			textArea = guiText.GetScreenRect();
			result += (words[i] + "\n");
		}
		return textArea;
	}

	// Use this for initialization
	void Start () {
		FormatGuiTextArea(guiText);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
