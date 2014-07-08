using UnityEngine;
using System.Collections;

public class CrashDetection : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		SendMessage("PlayerDeath");
	}
}
