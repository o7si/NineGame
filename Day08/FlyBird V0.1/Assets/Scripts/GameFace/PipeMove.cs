using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour {

	private float pipeMoveSpeed = 5.0f;		// 管道移动速度
	private float destroyPostion = -4.0f;	// 管道销毁位置

	void Start() {
		pipeMoveSpeed = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().pipeMoveSpeed;
	}

	void Update () {
		transform.Translate (new Vector3 (-pipeMoveSpeed * Time.deltaTime, 0, 0));
		if (transform.position.x < destroyPostion) {
			Destroy (gameObject);
		}
	}
}
