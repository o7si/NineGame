using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float force = 500.0f;

	public float start = 0;
	public float end = 0;
	public float time = 0;
	public string dir;

	public int score = 0;

	void OnCollisionEnter(Collision collision) {
		timeb = Time.time;
		if (collision.transform.name == "final") {
			dir = GameObject.Find ("Main").GetComponent<GenerateCube> ().generate ();
			collision.transform.name = "0w0";
			score++;
		}
	}

	// JumpDistance  D = time * 10;
	public float distance;

	IEnumerator JumpToTheFront(float dis, string dir) {
		float frontRate = dis / 2 * Time.deltaTime;
		if (dir == "Front") {
			float tempA = transform.position.x + dis;
			while (transform.position.x < tempA) {
				transform.Translate (new Vector3 (frontRate, 0, 0));
				yield return null;
			} 
		} else if (dir == "Left") {
			float tempB = transform.position.z + dis;
			while (transform.position.z < tempB) {
				transform.Translate (new Vector3 (0, 0, frontRate));
				yield return null;
			}
		}
		yield return null;
	}
		
	// Debug
	public float maxHeight = 0;
	public float minHeight = 100;
	public float timea = 0;
	public float timeb = 0;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			start = Time.time;
		} 
		if (Input.GetKeyUp (KeyCode.Space)) {
			end = Time.time;
			time = end - start;
			distance = time * 10;
			transform.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
			StartCoroutine (JumpToTheFront (distance, dir));
			timea = Time.time;
		}
		if (transform.position.y > maxHeight) {
			maxHeight = transform.position.y;
		}
		if (transform.position.y < minHeight) {
			minHeight = transform.position.y;
		}
	}
}