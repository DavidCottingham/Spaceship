using UnityEngine;
using System.Collections;

public class IncreaseScore : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		//increase score
		BroadcastMessage("Increment", 10);
	}
}
