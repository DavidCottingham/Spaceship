using UnityEngine;
using System.Collections;

public class HighScoreGui : MonoBehaviour {

	private int hiScore = 0;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey("Score")) {
			hiScore = PlayerPrefs.GetInt("Score");
		}
		guiText.text = "High Score: " + hiScore;
	}
}
