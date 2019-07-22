using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltToLeft : MonoBehaviour {

	private float conveyorBeltSpeed = 3.0f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().OnConveyorBeltEnter (conveyorBeltSpeed, "toLeft");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ().OnConveyorBeltExit (conveyorBeltSpeed, "toLeft");
		}
	}

	void Start () {
		conveyorBeltSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().conveyorBeltSpeed;
	}

}
