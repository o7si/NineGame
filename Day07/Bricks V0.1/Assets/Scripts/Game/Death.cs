using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "Ball") {
			StartCoroutine (GameObject.Find ("GameManager").GetComponent<GameManager> ().GameOver ());
		}
	}

}
