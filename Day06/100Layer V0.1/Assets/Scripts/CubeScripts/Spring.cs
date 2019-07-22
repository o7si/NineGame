using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {

	private float jumpHeight = 3.0f;
	private float jumpSpeed = 0.2f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			StartCoroutine (StartUp (other.gameObject, jumpHeight));
		}
	}

	IEnumerator StartUp(GameObject obj, float k) {
		while (k >= 0) {
			obj.transform.Translate (new Vector3 (0, jumpSpeed, 0));
			k -= jumpSpeed;
			yield return null;
		}
		yield return null;
	}
		
	void Start () {
		jumpHeight = GameObject.Find ("GameManager").GetComponent<GameManager> ().jumpHeight;
		jumpSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().jumpSpeed;
	}

}
