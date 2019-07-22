using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {

	private float snowSpeed = 3.0f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<Player> ().OnSnowEnter (snowSpeed);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<Player> ().OnSnowExit (snowSpeed);
		}
	}

	void Start () {
		snowSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().snowSpeed;
	}

}
