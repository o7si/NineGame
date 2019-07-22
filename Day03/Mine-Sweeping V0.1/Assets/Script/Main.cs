using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

	const int maxn = 10;
	const int mineNum = 10;
	const int isMine = 9;

	int[,] gameMap = new int[maxn, maxn];
	GameObject[,] plane = new GameObject[maxn, maxn];
	GameObject[,] mine = new GameObject[maxn, maxn];

	int[] dx = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 }; 
	int[] dy = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };

	public Material[] material = new Material[10];

	public Material planeMaterial;

	public GameObject MAP;
	public GameObject A;
	public GameObject B;
	public GameObject Particle;

	void Initial() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				gameMap [i, j] = 0;
			}
		}
		System.Random rd = new System.Random ();
		int cnt = 0;
		while (cnt < mineNum) {
			int x = rd.Next (maxn);
			int y = rd.Next (maxn);
			if (gameMap [x, y] == 0) {
				gameMap [x, y] = isMine;
				cnt++;
			}
		}
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == isMine)
					continue;
				for (int k = 0; k < 8; k++) {
					int x = i + dx [k];
					int y = j + dy [k];
					if (x < 0 || x >= maxn || y < 0 || y >= maxn)
						continue;
					if(gameMap[x, y] == isMine)
						gameMap [i, j]++;
				}
			}
		}
		// Test
		//printGameMap ();
		GenerateModelMap ();
	}

	public void open(int x, int y) {
		if (gameMap [x, y] == 0) {
			BFS (new Point (x, y));
		} else if (gameMap [x, y] != 9) {
			Destroy (plane [x, y]);
		} else {
			Fail ();
			GameObject.Find ("A/Result").GetComponent<Text> ().text = "游戏失败";
			over = true;
			StartCoroutine (Move ());
		}
	}
		
	public struct Point {
		public int x;
		public int y;
		public Point(int x, int y) {
			this.x = x;
			this.y = y;
		}
	};

	void BFS(Point start) {
		Queue<Point> que = new Queue<Point> ();
		que.Enqueue (start);
		while (que.Count != 0) {
			Point temp = que.Dequeue ();
			gameMap [temp.x, temp.y] = -1;
			Destroy (plane [temp.x, temp.y]);
			for (int k = 0; k < 8; k++) {
				int x = temp.x + dx [k];
				int y = temp.y + dy [k];
				if (x < 0 || x >= maxn || y < 0 || y >= maxn)
					continue;
				if (gameMap [x, y] == 0)
					que.Enqueue (new Point (x, y));
				else
					Destroy (plane [x, y]);
			}
		}
	}

	void Fail() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == isMine) {
					Destroy (plane [i, j]);
					Instantiate (Particle, new Vector3 (i, 0, j), Quaternion.identity);
				}
			}
		}
	}

	// Test
	void GenerateModelMap() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				plane [i, j] = Instantiate (A, new Vector3 (i, 0.5f, j), Quaternion.identity);
				plane [i, j].transform.name = "[" + i + "," + j + "]" + "UP";
				plane [i, j].transform.parent = MAP.transform;
				plane [i, j].GetComponent<MeshRenderer> ().material = planeMaterial;
				mine [i, j] = Instantiate (B, new Vector3 (i, 0, j), Quaternion.Euler (0, 90.0f, 0));
				mine [i, j].transform.name = "[" + i + "," + j + "]" + "DOWN";
				mine [i, j].transform.parent = MAP.transform;
				mine [i, j].GetComponent<MeshRenderer> ().material = material [gameMap [i, j]];
			}
		}
	}

	// Debug
	void printGameMap() {
		GameObject obj = GameObject.Find ("A/B");
		obj.GetComponent<Text> ().text = "";
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				obj.GetComponent<Text>().text += gameMap[i, j] + "   "; 
			}
			obj.GetComponent<Text>().text += '\n';
		}
	}

	// Use this for initialization
	void Start () {
		this.Initial ();
	}

	bool over = false;

	IEnumerator Move() {
		GameObject obj = GameObject.Find ("A/Result");
		float len = 800.0f;
		while (len >= 0) {
			len -= 1.0f;
			obj.GetComponent<RectTransform> ().Translate(new Vector3(0, -1.0f, 0));
			yield return null;
		}
		yield return null;
	}

	// Update is called once per frame
	void Update () {
		if (over)
			return;
		int cnt = 0;
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (plane [i, j] != null)
					cnt++;
			}
		}
		if (cnt == mineNum) {
			GameObject.Find ("A/Result").GetComponent<Text> ().text = "游戏胜利";
			over = true;
			StartCoroutine (Move ());
		}
	}
}