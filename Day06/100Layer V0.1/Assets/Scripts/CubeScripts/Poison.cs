using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour {

	private float needleDamage = 20.0f;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.GetComponent<Player> ().Damage (needleDamage);
		}
	}

	// Use this for initialization
	void Start () {
		needleDamage = GameObject.Find ("GameManager").GetComponent<GameManager> ().needleDamage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
