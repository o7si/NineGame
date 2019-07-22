using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SudokuGenerate : MonoBehaviour {

	const int maxn = 9;
	int[,] gameMap = new int[maxn, maxn];

	public bool isFind = false;

	public GameObject finalCube;
	public GameObject changeCube;

	public GameObject win;

	public Material[] finalMaterial = new Material[9];
	public Material changeMaterial;

	void memset() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				gameMap [i, j] = 0;
			}
		}
	}

	bool judge() {
		for (int i = 0; i < maxn; i++) {
			HashSet<int> sRow = new HashSet<int> ();
			HashSet<int> sColumn = new HashSet<int> ();
			int cntRow = 0, cntColumn = 0;
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == 0)
					cntRow++;
				else
					sRow.Add (gameMap [i, j]);
				if (gameMap [j, i] == 0)
					cntColumn++;
				else
					sColumn.Add (gameMap [j, i]);
			}
			if (sRow.Count + cntRow != maxn || sColumn.Count + cntColumn != maxn)
				return false;
		}
		int[] centerX = new int[9] { 1, 1, 1, 4, 4, 4, 7, 7, 7 };
		int[] centerY = new int[9] { 1, 4, 7, 1, 4, 7, 1, 4, 7 };
		int[] dx = new int[9] { 0, -1, -1, 0, 1, 1, 1, 0, -1 };
		int[] dy = new int[9] { 0, 0, -1, -1, -1, 0, 1, 1, 1 };
		for (int i = 0; i < 9; i++) {
			HashSet<int> sGrid = new HashSet<int> ();
			int cntGrid = 0;
			for (int k = 0; k < 9; k++) {
				int x = centerX [i] + dx [k];
				int y = centerY [i] + dy [k];
				if (gameMap [x, y] == 0)
					cntGrid++;
				else
					sGrid.Add (gameMap [x, y]);
			}
			if (sGrid.Count + cntGrid != maxn)
				return false;
		}
		return true;
	}

	bool Full() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] == 0)
					return false;
			}
		}
		return true;
	}

	void Generate(int num) {
		if (num >= maxn * maxn || isFind) {
			isFind = true;
			return;
		}
		int x = num / maxn, y = num % maxn;
		List<int> list = new List<int> ();
		for (int i = 1; i <= maxn; i++)
			list.Add (i);
		while (list.Count != 0) {
			if (isFind)
				return;
			System.Random rd = new System.Random ();
			int random = rd.Next (list.Count);
			gameMap [x, y] = list [random];
			list.RemoveAt (random);
			if (judge ())
				Generate (num + 1);
		}
		if(!isFind)
			gameMap [x, y] = 0;
	}

	void AddSpace() {
		int num = 30;
		System.Random rd = new System.Random ();
		while (num > 0) {
			int x = rd.Next (maxn);
			int y = rd.Next (maxn);
			if (gameMap [x, y] != 0) {
				gameMap [x, y] = 0;
				num--;
			}
		}
	}

	void GenerateModel() {
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				if (gameMap [i, j] != 0) {
					GameObject obj1 = Instantiate (finalCube, new Vector3 (i, 0, j), Quaternion.identity);
					obj1.GetComponent<MeshRenderer> ().material = finalMaterial [gameMap [i, j] - 1];
					obj1.transform.name = "Final [" + i + "," + j + "]";
					obj1.transform.parent = gameObject.transform;
				} else {
					GameObject obj2 = Instantiate (changeCube, new Vector3 (i, 0, j), Quaternion.identity);
					obj2.GetComponent<MeshRenderer> ().material = changeMaterial;
					obj2.transform.name = "Change [" + i + "," + j + "]";
					obj2.transform.parent = gameObject.transform;
				}
			}
		}
	}

	public void setNum(int x, int y, int num) {
		gameMap [x, y] = num;
		if (Full () && judge()) {
			StartCoroutine (Move ());
		}
	}

	IEnumerator Move() {
		float temp = 500.0f;
		float rate = 2.0f;
		while (temp > 0) {
			win.GetComponent<RectTransform> ().Translate (new Vector3 (0, -rate, 0));
			temp -= rate;
			yield return null;
		}
		yield return null;
	}

	//Debug
	void printMap() {
		GameObject obj = GameObject.Find ("Canvas/Map");
		obj.GetComponent<Text> ().text = "";
		for (int i = 0; i < maxn; i++) {
			for (int j = 0; j < maxn; j++) {
				obj.GetComponent<Text>().text += gameMap[i, j] + " ";
			}
			obj.GetComponent<Text> ().text += "\n";
		}
		obj.GetComponent<Text> ().text += "\n";
	}

	// Use this for initialization
	void Start () {
		memset ();
		Generate (0);
		printMap ();
		AddSpace ();
		GenerateModel ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
