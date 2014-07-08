using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private int buttonWidth = 200;

	// Use this for initialization
	void Start () {
	}
	
	void OnGUI() {		
		GUILayout.BeginArea (new Rect (Screen.width/2 - buttonWidth/2, Screen.height/2, buttonWidth, 200));
		GUILayout.Box("Dodge the Ships");
		if (GUILayout.Button ("Play Game")) {
			GetComponent<MainManager>().gameUnpause();
			GetComponent<MainMenu>().enabled = false;			
		}
		if (GUILayout.Button ("Credits")) {
			GetComponent<MainManager>().gameUnpause();
			Application.LoadLevel("Credits");
			GetComponent<MainMenu>().enabled = false;
		}
		if (GUILayout.Button ("Quit Game")) {
			Application.Quit();
		}
		GUILayout.EndArea ();
	}
}
