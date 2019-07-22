using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

	public Material enterMaterial;
	public Material exitMaterial;
	public Material signMaterial;

	bool sign = false;

	void OnMouseEnter() {
		transform.GetComponent<MeshRenderer> ().material = enterMaterial;
	}

	void OnMouseExit() {
		if (sign) {
			transform.GetComponent<MeshRenderer> ().material = signMaterial;
		} else {
			transform.GetComponent<MeshRenderer> ().material = exitMaterial;
		}
	}

	void OnMouseOver() {

		if (Input.GetMouseButtonDown (0)) {
			if (sign)
				return;
			string name = gameObject.transform.name;
			int[] array = new int[2];
			int k = 0;
			for (int i = 0; i < name.Length; i++) {
				if (name [i] >= '0' && name [i] <= '9') {
					for (int j = i; j < name.Length; j++) {
						if (name [j] >= '0' && name [j] <= '9')
							array [k] = array [k] * 10 + name [j] - '0';
						else {
							k++;
							break;
						}
					}
				} 
			}
			GameObject.Find ("Main").GetComponent<Main> ().open (array[0], array[1]);
		}
		if (Input.GetMouseButtonDown (1)) {
			sign = !sign;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
