using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

	private float tickSeconds = 5.0f;
	private float timeElapsed = 0.0f;

	// Use this for initialization
	void Start () {
		audio.ignoreListenerVolume = true;
		gamePause();
	}
	
	// Update is called once per frame
	void Update () {
		//Menu / pause handling
		if (Input.GetButtonDown("Menu")) {
			if (GetComponent<MainMenu>().enabled) {
				GetComponent<MainMenu>().enabled = false;
				gameUnpause();
			} else {
				GetComponent<MainMenu>().enabled = true;
				gamePause();
			}
		}
		timeElapsed += Time.deltaTime;
	}
	
	public void gamePause() {
		AudioListener.volume = 0.0f;
		StopCoroutine("CountedTick");
		Time.timeScale = 0.0f;
	}
	
	public void gameUnpause() {
		AudioListener.volume = 0.9f;
		Time.timeScale = 1.0f;
		StartCoroutine("CountedTick");
	}
	
	IEnumerator CountedTick() {
		//Debug.Log(timeElapsed);
		while(true) {
			if (timeElapsed >= tickSeconds) {
				timeElapsed = 0.0f;
				//broadcast message: increase speeds
				BroadcastMessage("IncreaseSpeed");
				//broadcast: increase x2 spawn chance
				BroadcastMessage("IncreaseSpawnChance");
			}
			yield return new WaitForSeconds(tickSeconds);
		}
	}
}
