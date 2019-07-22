using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] sprite = new Sprite[4];
	public int spriteCnt = 0;
	public int count = 0;

	void OnCollisionEnter2D (Collision2D other) {
		if (other.transform.tag == "Ball") {
			spriteCnt++;
			GameObject.Find ("GameManager").GetComponent<GameManager> ().AddScore (spriteCnt);
			ChangeSelfSprite ();
		}
	}

	void ChangeSelfSprite() {
		Debug.Log ("cnt: " + spriteCnt + ", len: " + sprite.Length);
		if (spriteCnt >= sprite.Length) {
			Destroy (gameObject);
			count--;
			if (count == 0) {
				GameObject.Find ("GameManager").GetComponent<GenerateBrick> ().GenerateGameBrick ();
			} 
		} else {
			transform.GetComponent<SpriteRenderer> ().sprite = sprite [spriteCnt];
		}
	}

	// Use this for initialization
	void Start () {
		count = GameObject.Find ("GameManager").GetComponent<GenerateBrick> ().sumBrick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
