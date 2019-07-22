using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollider : MonoBehaviour {

	private void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Head") {
			GameObject.Find ("GameController").GetComponent<GameController> ().GameOver ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
