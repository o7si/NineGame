using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject needlePrefab;
	public GameObject scoreObj;
	private Camera cameraMain;
	private Needle needle;
	private Transform startPoint;

	public bool isGameOver = false;

	public int score = 0;

	// Use this for initialization
	void Start () {
		startPoint = GameObject.Find ("StartPoint").transform;
		cameraMain = Camera.main;
		GenerateNeedle ();
	}

	public void GenerateNeedle() {
		needle = Instantiate (needlePrefab, startPoint.position, needlePrefab.transform.rotation).GetComponent<Needle>();
	}

	public void GameOver() {
		isGameOver = true;
		GameObject.Find ("Round").GetComponent<Rotate> ().enabled = false;
		cameraMain.backgroundColor = Color.red;
		cameraMain.orthographicSize = 4.0f;
		StartCoroutine (Fail ());
	}

	IEnumerator Fail() {
		yield return new WaitForSeconds (1.0f);
		SceneManager.LoadScene ("GameScene");
	}

	// Update is called once per frame
	void Update () {
		if (isGameOver)
			return;
		if (Input.GetMouseButtonDown (0)) {
			needle.MoveSelf ();
			GenerateNeedle ();
			scoreObj.GetComponent<Text> ().text = (++score).ToString();
		}
	}
}
