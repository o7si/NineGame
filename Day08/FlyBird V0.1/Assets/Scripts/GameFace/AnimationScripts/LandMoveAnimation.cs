using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandMoveAnimation : MonoBehaviour {

	public Sprite[] landSprite = new Sprite[spriteNum];
	private const int spriteNum = 2;
	private int nowSprite = 0;

	void Start() {
		StartCoroutine (ChangeSprite ());
	}

	IEnumerator ChangeSprite() {
		while (true) {
			int temp = (nowSprite++) % spriteNum;
			transform.GetComponent<Image> ().sprite = landSprite [temp];
			yield return new WaitForSeconds (0.05f);
			yield return null;
		}
	}

}
