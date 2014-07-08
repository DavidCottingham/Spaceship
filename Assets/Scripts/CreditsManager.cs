using UnityEngine;
using System.Collections;

public class CreditsManager : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//Menu / pause handling
		if (Input.GetButtonDown("Menu")) {
			togglePause();
			if (GetComponent<CreditsMenu>().enabled) {
				GetComponent<CreditsMenu>().enabled = false;
			} else {
				GetComponent<CreditsMenu>().enabled = true;
			}
		}
	}
	
	public void togglePause() {
		if (Time.timeScale == 1.0f) { gamePause(); }
		else { gameUnpause(); }
	}
	
	public void gamePause() {
		Time.timeScale = 0.0f;
	}
	
	public void gameUnpause() {
		Time.timeScale = 1.0f;
	}
}
