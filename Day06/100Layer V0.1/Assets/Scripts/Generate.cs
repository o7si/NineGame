using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {

	public GameObject[] gameCube = new GameObject[7];

	private float generateHeight = -5.5f;
	private float generateInterval = 0.5f;

	// Use this for initialization
	void Start () {
		generateHeight = GameObject.Find ("GameManager").GetComponent<GameManager> ().generateHeight;
		generateInterval = GameObject.Find ("GameManager").GetComponent<GameManager> ().generateInterval;
		GenerateCube ();
	}

	void GenerateCube() {
		StartCoroutine (Load ());
	}

	IEnumerator Load() {
		System.Random rd = new System.Random ();
		while (true) {
			yield return new WaitForSeconds (generateInterval);
			int random = rd.Next (gameCube.Length);
			float temp = rd.Next (-2, 2);
			GameObject obj = Instantiate (gameCube [random], new Vector3 (temp, generateHeight, 0), Quaternion.identity);
		}
	}

}
