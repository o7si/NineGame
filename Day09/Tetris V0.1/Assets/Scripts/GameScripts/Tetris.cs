using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetris : MonoBehaviour {

	private const int maxX = 20;
	private const int maxY = 10;
	private const int increment = 4;
	private const int xOffset = 0;
	private const int yOffset = 3;
	private int[,] gameMapArr = new int[maxX + increment, maxY];
	private List<Vector2> downList = new List<Vector2> ();
	private Image[,] gameMapImage = new Image[maxX + increment, maxY];
	public GameObject imagePrefab;
	//public Sprite testSprite;

	void Start() {
		GenerateBricks ();
		//BricksDownMove ();
		InvokeRepeating ("BricksDownMove", 0, 1.8f);
	}

	void GenerateBricks() {
		int[,] brick = new int[4, 4] {
			{ 0, 0, 0, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 1, 1, 0 },
			{ 0, 0, 0, 0 }
		};
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				if (brick [i, j] == 1)
					downList.Add (new Vector2 (i + xOffset, j + yOffset));
				gameMapArr [i + xOffset, j + yOffset] = brick [i, j];
			}
		}
	}

	void Swap<T> (ref T a, ref T b) { T t = a; a = b; b = t; }

	void BricksDownMove() {
		for (int i = downList.Count - 1; i >= 0; i--) {
			int x = (int)downList [i].x;
			int y = (int)downList [i].y;
			Swap (ref gameMapArr [x + 1, y + 0], ref gameMapArr [x, y]);
			downList [i] = new Vector2 (x + 1, y + 0);
		}
		GenerateSprite ();
	}

	void GenerateSprite() {
		for (int i = 0; i < maxX + increment; i++) {
			for (int j = 0; j < maxY; j++) {
				if (gameMapArr [i, j] == 0)
					continue;
				GameObject obj = Instantiate (imagePrefab);
				obj.transform.SetParent (GameObject.Find("BricksHolder").transform, false);
				obj.transform.localPosition = new Vector3 (i * 20.0f, j * 20.0f, 0);
			}
		}
	}

}
