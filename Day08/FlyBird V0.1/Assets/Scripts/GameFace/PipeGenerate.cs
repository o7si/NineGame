using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerate : MonoBehaviour {

	private float pipeGenerateTime = 0;
	public Transform startPoint;
	public GameObject pipePrefab;

	void Start() {
		pipeGenerateTime = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().pipeGenerateTime;
		StartCoroutine (Generate ());
	}

	IEnumerator Generate() {
		System.Random rd = new System.Random ();
		while (true) {
			float random = rd.Next (-4, 0);
			Instantiate (pipePrefab, new Vector3 (startPoint.position.x, random, 0), Quaternion.identity);
			yield return new WaitForSeconds (pipeGenerateTime);
		}
	}

}
