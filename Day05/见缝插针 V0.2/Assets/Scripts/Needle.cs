using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {

	private GameObject center;
	private Transform readyPoint;
	private Transform endPoint;

	public bool isReady = false;
	public bool isFly = false;

	public float readyMoveRate = 3.0f;
	public float flyMoveRate = 10.0f;

	private const float dev = 0.05f;

	public void MoveSelf() {
		isFly = true;
	}

	// Use this for initialization
	void Start () {
		center = GameObject.Find ("Round");
		readyPoint = GameObject.Find ("ReadyPoint").transform;
		endPoint = GameObject.Find ("EndPoint").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFly) {
			transform.position = Vector3.MoveTowards (transform.position, endPoint.position, flyMoveRate * Time.deltaTime);
			if (Vector3.Distance (endPoint.position, transform.position) < dev) {
				transform.position = endPoint.position;
				transform.parent = center.transform;
				isFly = false;
			}
		} else {
			if (!isReady) {
				transform.position = Vector3.MoveTowards (transform.position, readyPoint.position, readyMoveRate * Time.deltaTime);
				if (Vector3.Distance (readyPoint.position, transform.position) < dev) {
					transform.position = readyPoint.position;
					isReady = true;
				}
			}
		}
	}
}
