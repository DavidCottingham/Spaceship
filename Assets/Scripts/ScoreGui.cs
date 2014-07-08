using UnityEngine;
using System.Collections;

public class ScoreGui : MonoBehaviour {
	
	private int score = 0;

	void Increment(int inc) {
		score += inc;
		guiText.text = "Score: " + score;
	}
	
	void PlayerDeath() {
		if (score > PlayerPrefs.GetInt("Score")) {
			PlayerPrefs.SetInt("Score", score);
			PlayerPrefs.Save();
		}
	}
}
