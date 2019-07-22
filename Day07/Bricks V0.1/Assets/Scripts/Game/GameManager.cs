using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// GenerateBrick.cs
	public int longMaxX = 12;
	public int longMaxY = 5;
	public int shortMaxX = 11;
	public int shortMaxY = 5;
	// Baffle.cs
	public float baffleMoveSpeed = 5.0f;

	public Text scoreText;
	public int score = 0;

	public void AddScore(int score) {
		this.score += score;
		scoreText.text = "Score:" + this.score;
	}
		
	public IEnumerator GameOver() {
		Destroy (GameObject.FindGameObjectWithTag ("Ball"));
		scoreText.color = Color.red;
		scoreText.fontSize = 30;
		while (true) {
			scoreText.transform.position = Vector2.MoveTowards (scoreText.transform.position, Vector2.zero, 1.0f * Time.deltaTime);
			if (Vector2.Distance (scoreText.transform.position, Vector2.zero) < 0.05f)
				break;
			yield return null;
		}
		yield return new WaitForSeconds (2.0f);
		SceneManager.LoadScene ("Bricks");
		yield return null;
	}

}
