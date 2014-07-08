using UnityEngine;
using System.Collections;

public class GlowFlicker : MonoBehaviour {

	private float min = 1.5f;
	private float max = 3.0f;
	private float intensity;
	private float randomChoice;
	private float prevChoice;
	
	void Start() {
		randomChoice = Random.Range(min,max);
		prevChoice = min;
	}
	
	// Update is called once per frame
	void Update () {
		if (light.intensity != randomChoice) {
			if (randomChoice > prevChoice) {
				//randomChoice > prev, lerp prev to choice
				// else choice to prev
				intensity = Mathf.Lerp(prevChoice, randomChoice, Time.time /2);
			} else {
				intensity = Mathf.Lerp(randomChoice, prevChoice, Time.time /2);
			}
			light.intensity = intensity;
			prevChoice = randomChoice;
		} else { randomChoice = Random.Range(min,max); }
	}
}
