using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public bool isCollision = false;

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log (coll.gameObject.name);
		if(coll.gameObject.name == "Center") {
			isCollision = true;
			transform.parent = coll.gameObject.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		if (isCollision)
			return;
		transform.Translate (new Vector3(1f, 0, 0));
	}
}
