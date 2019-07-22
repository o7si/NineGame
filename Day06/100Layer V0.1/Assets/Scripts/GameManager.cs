using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float cubeUpSpeed = 10.0f;
	public float conveyorBeltSpeed = 3.0f;
	public float snowSpeed = 3.0f;
	public float generateHeight = -5.5f;
	public float generateInterval = 0.5f;
	public float destroyHeight = 7.0f;
	public float playerLeftSpeed = 3.0f;
	public float playerRightSpeed = 3.0f;
	public float playerDownSpeed = 3.0f;
	public float jumpHeight = 3.0f;
	public float jumpSpeed = 0.2f;
	public float needleDamage = 30.0f;

	public GameObject score;

	private float scoreMoveSpeed = 2.5f;

	public IEnumerator GameOver() {
		
		while (true) {
			score.transform.position = Vector3.MoveTowards (score.transform.position, Vector3.zero, scoreMoveSpeed * Time.deltaTime);
			if (Vector3.Distance (Vector3.zero, score.transform.position) < 0.05f)
				break;
			yield return null;
		}
		yield return new WaitForSeconds (2.0f);
		yield return null;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
