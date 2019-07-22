using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baffle : MonoBehaviour {

	public bool isStart = false;	
	public bool isLeft = false;
	public bool isRight = false;
	private float baffleMoveSpeed = 3.0f;

	void Start() {
		baffleMoveSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().baffleMoveSpeed;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			isLeft = true;
		} 
		if (Input.GetKeyUp (KeyCode.A)) {
			isLeft = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			isRight = true;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			isRight = false;
		}
		if (isLeft) {
			if (transform.position.x < -8.3f)
				return;
			transform.Translate (new Vector2 (-baffleMoveSpeed * Time.deltaTime, 0));	
		}
		if (isRight) {
			if (transform.position.x > 8.3f)
				return;
			transform.Translate (new Vector2 (baffleMoveSpeed * Time.deltaTime, 0));
		}
		if (Input.GetKeyDown(KeyCode.Return) && !isStart) {
			isStart = true;
			GameObject.FindGameObjectWithTag ("Ball").GetComponent<BallMove> ().StartMove ();
		}
	}
}
