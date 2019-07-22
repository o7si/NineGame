using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillNumber : MonoBehaviour {

	public GameObject Main;
	public GameObject tip;

	public Material[] changeMaterial = new Material[9];

	GameObject temp;

	public bool isMouseEnter = false;
	public int x;
	public int y;

	void OnMouseEnter() {
		isMouseEnter = true;
		temp = Instantiate (tip, gameObject.transform);
	}

	void OnMouseExit() {
		isMouseEnter = false;
		Destroy (temp);	
	}

	// Use this for initialization
	void Start () {
		string name = gameObject.transform.name;
		x = name[8] - '0';
		y = name[10] - '0';
		Main = GameObject.Find("Main");
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMouseEnter)
			return;
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [0];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [1];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [2];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 3);
		} 
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [3];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 4);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [4];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 5);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [5];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 6);
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [6];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 7);
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [7];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 8);
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			gameObject.GetComponent<MeshRenderer> ().material = changeMaterial [8];
			Main.GetComponent<SudokuGenerate> ().setNum (x, y, 9);
		}
	}
}
