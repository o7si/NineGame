using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Fail : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0.0f) {

			SceneManager.LoadScene("GameOver");
		}	
	}
}
