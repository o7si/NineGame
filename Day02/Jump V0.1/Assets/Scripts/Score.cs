using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	void Start() {

	}

	// Update is called once per frame
	void Update () {
		transform.GetComponent<Text> ().text = "你的最终得分: 还没加入计分的东东";
	}
}
