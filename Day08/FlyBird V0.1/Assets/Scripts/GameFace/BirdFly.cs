using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdFly : MonoBehaviour {

	private float birdUpSpeed = 0;
	public Transform topPoint;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Bottom" || other.tag == "Pipe") {
			Debug.Log ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1");
			StartCoroutine(GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().GameOver ());
		} else if (other.tag == "Top") {
			transform.position = topPoint.position;
		} else if (other.tag == "Score") {
			GameObject.Find ("GameFace").GetComponent<GameController> ().AddScore (1);
		}
	}

	void Start() {
		birdUpSpeed = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().birdUpSpeed;
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, birdUpSpeed);
		} 
	}
}
