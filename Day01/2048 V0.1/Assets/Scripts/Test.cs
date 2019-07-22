using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour {

	const int maxn = 4;
	int[,] gameMap = new int[maxn, maxn];

	public GameObject TEMP;
	public GameObject text;

	// 2^0 = 1; 2^1 = 2; 2^2 = 4 ……
	const int maxPow = 20;
	public GameObject[] numCube = new GameObject[maxPow];
	string[] numStr = new string[] { "0", "2", "4", "8", "16", "32", "64", "128", "256", "512", "1024", "2048" };

	public int score = 0;

	public struct Point {
		public int x;
		public int y;
		public Point(int x, int y) {
			this.x = x;
			this.y = y;
		}
	};
	// GameMap初始化
	void GameMapInitial() {
		score = 0;
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				gameMap [i, j] = 0;
			}
		}
		for (int i = 0; i < numStr.Length; i++) {
			numCube[i] = (GameObject)Resources.Load ("Prefabs/" + numStr [i]);
		}
		// 初始数字个数
		int k = 2;
		while (k != 0) {
			RandomPointGenerate ();
			k--;
		}
	}
	// 在空位列表中随机一个Point并随机放置一个数字
	void RandomPointGenerate() {
		List<Point> emptyPlace = EmptyPlaceGenerate ();
		System.Random rd = new System.Random ();
		int randomPos = rd.Next (emptyPlace.Count - 1);
		Point point = emptyPlace [randomPos];
		int randomNum = rd.Next(1, 3);
		gameMap [point.x, point.y] = randomNum * 2;
	}
	// 生成空位列表
	List<Point> EmptyPlaceGenerate() {
		List<Point> list = new List<Point> ();
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == 0)
					list.Add (new Point (i, j));
			}
		}
		return list;
	}
	// Swap
	void swap<T>(ref T a, ref T b) { T t = a; a = b; b = t; }
	// UpDirection
	void UpDir() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == 0)
					continue;
				int t = i;
				for (int k = 1; k <= t; k++) {
					if (gameMap [t - k, j] == 0) {
						swap (ref gameMap [t - k, j], ref gameMap [t, j]);
						t--;
						k--;
					} else if (gameMap [t - k, j] == gameMap [t, j]) {
						score += gameMap [t - k, j];
						gameMap [t - k, j] *= 2;
						gameMap [t, j] = 0;
						break;
					} else {
						break;
					}
				}
			}
		}
	}
	// DownDirection
	void DownDir() {
		for (int i = maxn - 1; i >= 0; i--) {
			for (int j = maxn - 1; j >= 0; j--) {
				if (gameMap [i, j] == 0)
					continue;
				int t = i;
				for (int k = 1; k <= maxn - t - 1; k++) {
					if (gameMap [t + k, j] == 0) {
						swap (ref gameMap [t + k, j], ref gameMap [t, j]);
						t++;
						k--;
					} else if (gameMap [t + k, j] == gameMap [t, j]) {
						score += gameMap [t + k, j];
						gameMap [t + k, j] *= 2;
						gameMap [t, j] = 0;
						break;
					} else {
						break;
					}
				}
			}
		}
	}
	// LeftDirection
	void LeftDir() {
		for (int j = 0; j < maxn; j++) {
			for (int i = 0; i < maxn; i++) {
				if (gameMap [i, j] == 0)
					continue;
				int t = j;
				for (int k = 1; k <= t; k++) {
					if (gameMap [i, t - k] == 0) {
						swap (ref gameMap [i, t - k], ref gameMap [i, t]);
						t--;
						k--;
					} else if (gameMap [i, t - k] == gameMap [i, t]) {
						score += gameMap [i, t - k];
						gameMap [i, t - k] *= 2;
						gameMap [i, t] = 0;
						break;
					} else {
						break;
					}
				}
			}
		}
	}
	// RightDirection
	void RightDir() {
		for (int j = maxn - 1; j >= 0; j--) {
			for (int i = maxn - 1; i >= 0; i--) {
				if (gameMap [i, j] == 0)
					continue;
				int t = j;
				for (int k = 1; k <= maxn - t - 1; k++) {
					if (gameMap [i, t + k] == 0) {
						swap (ref gameMap [i, t + k], ref gameMap [i, t]);
						t++;
						k--;
					} else if (gameMap [i, t + k] == gameMap [i, t]) {
						score += gameMap [i, t + k];
						gameMap [i, t + k] *= 2;
						gameMap [i, t] = 0;
						break;
					} else {
						break;
					}
				}
			}
		}
	}
	// Model
	void ModelGenerate() {
		Destroy (GameObject.Find ("0w0"));
		GameObject temp = Instantiate (TEMP, Vector3.zero, Quaternion.identity);
		temp.transform.name = "0w0";
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				int n = caclLn (gameMap [i, j]);
				GameObject obj = Instantiate (numCube [n], new Vector3 (i, 0, j), Quaternion.Euler(0, 90.0f, 0));
				obj.transform.parent = temp.transform;
			}
		}
	}
	// lnX
	int caclLn(int n) {
		int k = -1;
		do {
			n /= 2;
			k++;
		} while(n != 0);
		return k;
	}
	// GameFace
	void GameFace() {
		text.GetComponent<Text> ().text = "Score: " + score;
		ModelGenerate ();
	}
	// Fail
	bool Fail() {
		int[] dx = new int[4] { -1, 0, 1, 0 };
		int[] dy = new int[4] { 0, -1, 0, 1 };
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == 0)
					return false;
				for (int k = 0; k < 4; k++) {
					int x = i + dx [k];
					int y = j + dy [k];
					if (x < 0 || x >= maxn || y < 0 || y >= maxn)
						continue;
					if (gameMap [x, y] == gameMap [i, j])
						return false;
				}
			}
		}
		return true;
	}
	// Use this for initialization
	void Start () {
		GameMapInitial ();
	}
	// Update is called once per frame
	void Update () {
		GameFace ();
		if (!Fail ()) {
			if (Input.GetKeyDown (KeyCode.W)) {
				UpDir ();
				RandomPointGenerate ();
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				DownDir ();
				RandomPointGenerate ();
			}
			if (Input.GetKeyDown (KeyCode.A)) {
				LeftDir ();
				RandomPointGenerate ();
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				RightDir ();
				RandomPointGenerate ();
			}
		} else {
			text.GetComponent<Text>().text = "GameOver(" + score +")";
		}
	}
}
