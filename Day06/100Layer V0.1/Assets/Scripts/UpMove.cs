using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMove : MonoBehaviour {

	private float upSpeed = 10.0f;
	private float destroyHeight = 7.0f;

	// Use this for initialization
	void Start () {
		upSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().cubeUpSpeed;
		destroyHeight = GameObject.Find ("GameManager").GetComponent<GameManager> ().destroyHeight;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, upSpeed * Time.deltaTime, 0));
		if (transform.position.y > destroyHeight) {
			Destroy (gameObject);
		}
	}
}
