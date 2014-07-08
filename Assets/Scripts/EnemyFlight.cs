using UnityEngine;
using System.Collections;

public class EnemyFlight : MonoBehaviour {

	public float Speed {get; set;}
	
	// Update is called once per frame
	void Update () {
		//TODO get correct column pos from script
		transform.position += new Vector3(0.0f, -Speed * Time.deltaTime, 0.0f);
	}
	
	/*void SetSpeed(float speed) {
		if (this.speed < 20) {
			this.speed = speed;
		}
	}*/
}
