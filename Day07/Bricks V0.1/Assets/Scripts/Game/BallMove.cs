using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

	public void StartMove() {
		transform.parent = null;
		transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (5.0f, 5.0f);
	}
		
}
