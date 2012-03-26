using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,200,200), "Instructions");
		if(GUI.Button(new Rect(Screen.width / 2 - 200 / 2,Screen.height / 2 - 50 / 2,200,50), "Start Game"))
		{
			Application.LoadLevel(1);
		}
	}
}
