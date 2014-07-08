using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		transform.parent.BroadcastMessage("PlayerDeath");
	}
}
