using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltToRight : MonoBehaviour {

	private float conveyorBeltSpeed = 3.0f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().OnConveyorBeltEnter (conveyorBeltSpeed, "toRight");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().OnConveyorBeltExit (conveyorBeltSpeed, "toRight");
		}
	}

	void Start () {
		conveyorBeltSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().conveyorBeltSpeed;
	}

}
