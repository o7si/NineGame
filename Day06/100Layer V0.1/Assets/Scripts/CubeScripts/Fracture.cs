using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Player").transform.parent = null;
			StartCoroutine (Kill());
		}
	}

	IEnumerator Kill() {
		yield return new WaitForSeconds (1.0f);
		Destroy (gameObject);
	}
		
}
