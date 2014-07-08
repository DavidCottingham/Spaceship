using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Vector3 centerPos = new Vector3(0,0,0);
	private Vector3 leftPos = new Vector3(-10,0,0);
	private Vector3 rightPos = new Vector3(10,0,0);
	private float speed = 10.0f;
	
	private bool shouldMove = false;
	//private bool fromRight = false;
	
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//this happens every frame when not moving. bad for performance? especially send message?
		if (shouldMove && (transform.position == centerPos || transform.position == leftPos || transform.position == rightPos)) {
			shouldMove = false;
			SendMessage("Moving", "");
		}
		
		if (shouldMove) { move(); }
	
		if (!shouldMove && Input.GetButtonDown("Right")) {
			shouldMove = true;
			if (transform.position == centerPos) {
				SendMessage("Moving", "right");
				newPosition = rightPos;
				move();
			} else if (transform.position == leftPos) {
				SendMessage("Moving", "right");
				newPosition = centerPos;
				move();
			}
		}
		
		if (!shouldMove && Input.GetButtonDown("Left")) {
			shouldMove = true;
			if (transform.position == centerPos) {
				SendMessage("Moving", "left");
				newPosition = leftPos;
				move();
			} else if (transform.position == rightPos) {
				SendMessage("Moving", "left");
				newPosition = centerPos;
				move();
			}
		}
	/*
		if (Input.GetButtonDown("Right")) {
			//transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
			if (transform.position.x < rightPos.x) {
					transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
				}
			if (transform.position == centerPos) {
				//newPosition = rightPos;
				if (transform.position.x < rightPos.x) {
					transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
				}
			} else if (transform.position == leftPos) {
				//newPosition = centerPos;
				transform.position = new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
			}
		} else if (Input.GetButtonDown("Left")) {
			if (transform.position == centerPos) {
				//newPosition = leftPos;
				transform.position = new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
			} else if (transform.position == rightPos) {
				//newPosition = centerPos;
				transform.position = new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
			}
		}
		
		//transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothing);
		//transform.position = newPosition;
	*/
	}
	
	void move() {
		transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
	}
	
	void IncreaseSpeed() {
		if (speed < 24.9f) {
			speed += 0.5f;
		}
	}
}
