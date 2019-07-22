using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Sprite toLeft;
	public Sprite toRight;
	public Text scoreText;
	public Text hpText;

	private float leftSpeed = 3.0f;
	private float rightSpeed = 3.0f;
	private float downSpeed = 3.0f;
	private float score = 0.0f;
	public float hp = 100.0f;

	public bool isLeft = false;
	public bool isRight = false;
	public bool isGameOver = false;

	void OnTriggerEnter2D(Collider2D other) {
		transform.parent = other.transform;
	}

	void OnTriggerExit2D(Collider2D other) {
		transform.parent = null;
	}

	public void OnConveyorBeltEnter(float speed, string dir) {
		if (dir == "toRight") {
			leftSpeed -= speed;
			rightSpeed += speed;
		} else if (dir == "toLeft") {
			leftSpeed += speed;
			rightSpeed -= speed;
		}
	}

	public void OnConveyorBeltExit(float speed, string dir) {
		if (dir == "toRight") {
			leftSpeed += speed;
			rightSpeed -= speed;
		} else if (dir == "toLeft") {
			leftSpeed -= speed;
			rightSpeed += speed;
		}
	}

	public void OnSnowEnter(float speed) {
		leftSpeed -= speed;
		rightSpeed -= speed;
	}

	public void OnSnowExit(float speed) {
		leftSpeed += speed;
		rightSpeed += speed;
	}

	public void Damage(float damage) {
		hp -= damage;
		hpText.GetComponent<Text> ().text = "HP:" + hp;
		if (hp <= 0) {
			transform.GetComponent<SpriteRenderer> ().sprite = null;
			isGameOver = true;
			StartCoroutine (GameObject.Find ("GameManager").GetComponent<GameManager> ().GameOver ());
		}
	}
		
	void Start() {
		leftSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().playerLeftSpeed;
		rightSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().playerRightSpeed;
		downSpeed = GameObject.Find ("GameManager").GetComponent<GameManager> ().playerDownSpeed;
	}

	void Update () {
		if (isGameOver)
			return;
		if (Input.GetKeyDown (KeyCode.A)) {
			transform.GetComponent<SpriteRenderer> ().sprite = toLeft;
			isLeft = true;
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			isLeft = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			transform.GetComponent<SpriteRenderer> ().sprite = toRight;
			isRight = true;
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			isRight = false;
		}
		if (isLeft) {
			transform.Translate (new Vector3 (-leftSpeed * Time.deltaTime, 0, 0));
		}
		if (isRight) {
			transform.Translate (new Vector3 (rightSpeed * Time.deltaTime, 0, 0));
		}
		if (transform.parent == null) {
			transform.Translate (new Vector3 (0, -downSpeed * Time.deltaTime, 0));
			score += downSpeed * Time.deltaTime;
			scoreText.GetComponent<Text> ().text = ((int)(score * 100)).ToString ();
		}
	}
}
