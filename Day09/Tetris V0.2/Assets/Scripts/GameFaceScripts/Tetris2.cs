using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tetris2 : MonoBehaviour {

	private const int maxX = 20 + 4;
	private const int maxY = 10;
	private const float imagePx = 20.0f;
	private GameObject[,] gameMap = new GameObject[maxX, maxY];
	private List<Vector2> downList = new List<Vector2> ();
	public GameObject brickPrefab;
	public Sprite testSprite;

	void Start() {
		RandomBrick ();
		StartCoroutine (BrickDownMove ());
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.A)) {
			BrickMove ("Left");
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			BrickMove ("Right");
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			BrickMove ("Up");
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			BrickMove ("Down");
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			RandomBrick ();
		}
	}

	void PrintList(List<Vector2> list) {
		for (int i = 0; i < list.Count; i++) {
			Debug.Log (i + "-->" + toString (list [i]));
		}
	}

	string toString(Vector2 vec2) {
		return "[" + vec2.x + ", " + vec2.y + "]";
	}

	IEnumerator BrickDownMove() {
		while (true) {
			yield return new WaitForSeconds (0.1f);
			BrickMove ("Down");
			yield return null;
		}
	}

	void SetGameMap(int x, int y) {
		gameMap [x, y] = Instantiate (brickPrefab);
		gameMap [x, y].transform.SetParent (GameObject.Find ("BricksHolder").transform, false);
		gameMap [x, y].transform.localPosition = new Vector3 (y * imagePx - 90.0f, -x * imagePx + 230.0f, 0);
		gameMap [x, y].transform.name = toString (new Vector2 (x, y));
	}

	void RandomBrick() {
		int[,] brick = new int[7, 4] { 
			{ 3840, 8738, 240, 17476 }, 
			{ 36352, 25664, 3616, 17600 },
			{ 11776, 17504, 3712, 50240 },
			{ 26112, 26112, 26112, 26112 },
			{ 27648, 17952, 1728, 35904 },
			{ 19968, 17984, 3648, 19520 },
			{ 50688, 9792, 3168, 19584 }
		};
		int rdx = Random.Range (0, 7);
		int rdy = Random.Range (0, 4);
		int random = brick [rdx, rdy];
		//int random = 26112;
		int[,] array = new int[4, 4];
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				array [i, j] = random % 2;
				random /= 2;
			}
		}
		BrickGenerate (array);
	}

	void BrickGenerate(int[,] array) {
		downList.Clear ();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				if (array [i, j] == 0)
					continue;
				SetGameMap (i, j);
				downList.Add (new Vector2 (i, j));
			}
		}
	}

	void BrickMove (string dir) {
		List<Vector2> list1 = new List<Vector2> ();
		for (int i = 0; i < downList.Count; i++) {
			if (dir == "Up")
				list1.Add (new Vector2 (downList [i].x - 1, downList [i].y));
			else if (dir == "Down")
				list1.Add (new Vector2 (downList [i].x + 1, downList [i].y));
			else if (dir == "Left")
				list1.Add (new Vector2 (downList [i].x, downList [i].y - 1));
			else if (dir == "Right")
				list1.Add (new Vector2 (downList [i].x, downList [i].y + 1));
		}
		List<Vector2> list2 = new List<Vector2> ();
		for (int i = 0; i < list1.Count; i++) {
			bool sign = true;
			for (int j = 0; j < downList.Count; j++) {
				if (list1[i] == downList[j])
					sign = false;
			}
			if (sign)
				list2.Add (list1 [i]);
		}
		bool isMove = true;
		if (list2.Count == 0)
			isMove = false;
		for (int i = 0; i < list2.Count; i++) {
			int x = (int)list2 [i].x;
			int y = (int)list2 [i].y;
			if (x < 0 || x >= maxX || y < 0 || y >= maxY || gameMap[x, y] != null) {
				isMove = false;
				break;
			}
		}
		if (!isMove) {
			for (int i = 0; i < downList.Count; i++) {
				gameMap [(int)downList [i].x, (int)downList [i].y].GetComponent<Image> ().sprite = testSprite;
			}
			if (dir == "Down") {
				RemoveFullMain ();
				RandomBrick ();
			}
			return;
		}
		for (int i = 0; i < downList.Count; i++) {
			Destroy (gameMap [(int)downList [i].x, (int)downList [i].y]);
		}
		for (int i = 0; i < list1.Count; i++) {
			SetGameMap ((int)list1 [i].x, (int)list1 [i].y);
		}
		for (int i = 0; i < list1.Count; i++) {
			downList [i] = list1 [i];
		}
	}

	void RemoveFullMain () {
		for (int i = maxX - 1; i >= 0; i--) {
			if (IsFull(i)) {
				for (int j = 0; j < maxY; j++) {
					Destroy (gameMap [i, j]);
				}
				for (int k = i - 1; k >= 0; k--) {
					for (int j = 0; j < maxY; j++) {
						if (gameMap [k, j] == null)
							continue;
						Destroy (gameMap [k, j]);
						SetGameMap (k + 1, j);
					}
				}
			}
		}
	}

	bool IsFull(int k) {
		for (int j = 0; j < maxY; j++)
			if (gameMap [k, j] == null)
				return false;
		return true;
	}

}
