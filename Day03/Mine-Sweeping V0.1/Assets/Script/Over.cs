using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (transform.GetComponent<RectTransform> ().position.y < 0) {
			SceneManager.LoadScene ("GameOver");
		} 
	}
}
