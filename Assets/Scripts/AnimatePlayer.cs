using UnityEngine;
using System.Collections;

public class AnimatePlayer : MonoBehaviour {

	private bool movingRight = false;
	private bool movingLeft = false;
	private float speed = 1.0f;

	// Update is called once per frame
	void Update () {
		//why these directions backwards? :O
		if (movingRight) {
			transform.Rotate(Vector3.left, Time.deltaTime * 360 * speed);
			//transform.Rotate(-Time.deltaTime * 360, 0, 0);
		} else if (movingLeft) {
			transform.Rotate(Vector3.right, Time.deltaTime * 360 * speed);
			//transform.Rotate(Time.deltaTime * 360, 0, 0);
		}
	}
	
	void Moving(string direction) {
		if (direction.Equals("")) {
			movingLeft = false;
			movingRight = false;
			transform.eulerAngles = new Vector3(0, 270, 90); //to fix rotate errors compounding over time
		} else if (direction.Equals("right")) {
			movingRight = true;
			movingLeft = false;		//not sure if needed, but why not
		} else if (direction.Equals("left")) {
			movingLeft = true;
			movingRight = false;	//not sure if needed, but why not
		}
	}
	
	void IncreaseSpeed() {
		if (speed < 2.49f) {
			speed += 0.05f;
		}
	}
}
