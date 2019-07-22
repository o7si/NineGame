using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBrick : MonoBehaviour {

	public GameObject[] gameBricks = new GameObject[7];
	public GameObject map;
	private int longMaxX = 0;
	private int longMaxY = 0;
	private int shortMaxX = 0;
	private int shortMaxY = 0;
	public int sumBrick = 0;

	public void GenerateGameBrick() {
		System.Random rd = new System.Random ();
		for (int i = 0; i < shortMaxX; i++) {
			for (int j = 0; j < shortMaxY; j++) {
				int random = rd.Next (gameBricks.Length);
				GameObject gameobj1 = Instantiate (gameBricks [random], new Vector2 ((i - shortMaxX / 2) * -1.0f, j), Quaternion.identity);
				gameobj1.transform.parent = map.transform;
			}
		}
		for (int i = 0; i < longMaxX; i++) {
			for (int j = 0; j < longMaxY; j++) {
				int random = rd.Next (gameBricks.Length);
				GameObject gameobj2 = Instantiate (gameBricks [random], new Vector2 ((i - longMaxX / 2) * -1.0f - 0.5f, j - 0.5f), Quaternion.identity);
				gameobj2.transform.parent = map.transform;
			}
		}
	}
		
	void Start () {
		GameObject gameManager = GameObject.Find ("GameManager");
		longMaxX = gameManager.GetComponent<GameManager> ().longMaxX;
		longMaxY =	gameManager.GetComponent<GameManager> ().longMaxY;
		shortMaxX = gameManager.GetComponent<GameManager> ().shortMaxX;
		shortMaxY = gameManager.GetComponent<GameManager> ().shortMaxY;
		sumBrick = longMaxX * longMaxY + shortMaxX * shortMaxY;
		GenerateGameBrick ();
	}

}
