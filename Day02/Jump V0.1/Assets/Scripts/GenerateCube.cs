using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCube : MonoBehaviour {

	public GameObject father;
	public GameObject player;

	public GameObject temp;
	public const int maxNum = 20;
	public GameObject[] array = new GameObject[maxNum];
	public string[] str = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

	Vector3 vec = Vector3.zero;

	public string generate() {
		System.Random rd = new System.Random ();
		int random = rd.Next (2);
		string result = "";
		float len = rd.Next (5, 15);
		if (random == 0) {
			vec.x += len;
			result = "Front";
		} else if (random == 1) {
			vec.z += len;
			result = "Left";
		}
		int num = rd.Next (str.Length);
		temp = Instantiate (array[num], vec, Quaternion.identity);
		temp.transform.parent = father.transform;
		temp.transform.name = "final";
		return result;
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < str.Length; i++) {
			array [i] = (GameObject)Resources.Load ("Prefabs/" + str[i]);
		}
		temp = Instantiate (array[1], new Vector3(0, 0, 0), Quaternion.identity);
		temp.transform.parent = father.transform;
		temp.transform.name = "final";
		GameObject obj = Instantiate (player, new Vector3 (0, 10, 0), Quaternion.identity);
		obj.transform.name = "player";
	}
}
