using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdFlyAnimation : MonoBehaviour {

	public Sprite[] birdFlySprite = new Sprite[spriteNum];
	private const int spriteNum = 3;
	private int nowSprite = 0;

	void Start() {
		StartCoroutine (ChangeSprite ());
	}

	IEnumerator ChangeSprite() {
		while (true) {
			int temp = (nowSprite++) % spriteNum;
			transform.GetComponent<Image> ().sprite = birdFlySprite [temp];
			yield return new WaitForSeconds (0.05f);
			yield return null;
		}
	}
		
}
